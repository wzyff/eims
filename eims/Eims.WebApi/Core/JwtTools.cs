using JWT;
using JWT.Algorithms;
using JWT.Exceptions;
using JWT.Serializers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Eims.WebApi.Core
{
    public class JwtTools
    {
        public static string Key { get; set; } = "wangzhenyang";

        public static string Encode(Dictionary<string, object> payload, string key = null)
        {
            if (string.IsNullOrEmpty(key)) key = Key;
            payload.Add("timeout", DateTime.Now.AddDays(1));

            IJsonSerializer jsonSerializer = new JsonNetSerializer();//json序列化
            IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//base64加密编码器
            IJwtAlgorithm algorithm = new HMACSHA256Algorithm();//算法
            IJwtEncoder jwtEncoder = new JwtEncoder(algorithm, jsonSerializer, urlEncoder);
            return jwtEncoder.Encode(payload, key);
        }

        public static Dictionary<string, object> Decode(string code, string key = null)
        {
            if (string.IsNullOrEmpty(key)) key = Key;
            try
            {
                IJsonSerializer jsonSerializer = new JsonNetSerializer();//json序列化
                IDateTimeProvider provider = new UtcDateTimeProvider();//日期提供者
                IJwtValidator jwtValidator = new JwtValidator(jsonSerializer, provider);//验证器
                IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();//base64加密编码器
                IJwtAlgorithm algorithm = new HMACSHA256Algorithm();//算法
                IJwtDecoder jwtDecoder = new JwtDecoder(jsonSerializer, jwtValidator, urlEncoder, algorithm);
                var json = jwtDecoder.Decode(code, key, true);
                var result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

                if ((DateTime)result["timeout"] < DateTime.Now)
                    throw new Exception("jwtstring已经过期，必须重新登陆");
                result.Remove("timeout");
                return result;
            }
            catch (TokenExpiredException) { throw; }
        }
    }
}