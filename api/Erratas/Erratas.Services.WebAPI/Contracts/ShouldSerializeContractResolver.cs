using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Erratas.Services.WebAPI.Contracts
{
    public class ShouldSerializeContractResolver : DefaultContractResolver
    {
        public new static readonly ShouldSerializeContractResolver Instance =
                                   new ShouldSerializeContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member,
                                         MemberSerialization memberSerialization)
        {
            JsonProperty property = base.CreateProperty(member, memberSerialization);

            if (property.PropertyName == "ValidationResult" || property.PropertyName == "Senha" || property.PropertyName == "Ativo")
            {
                property.ShouldSerialize = instance =>
                {
                    return false;
                };
            }

            return property;
        }
    }
}