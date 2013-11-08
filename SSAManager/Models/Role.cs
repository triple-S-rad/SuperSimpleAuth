using System;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using Nancy.Validation;
using FluentValidation;

namespace SSAManager
{
    public class Role
    {
        [BsonId]
        public Guid Id { get; set; }
        [BsonElement]
        public string Name { get; set; }
        [BsonElement]
        public Guid AppId { get; set; }
        [BsonElement]
        public List<string> Claims { get; set; }
        [BsonIgnore]
        public string AppName { get; set; }
        [BsonIgnore]
        public Manager Manager { get; set; }
        [BsonIgnore]
        public IEnumerable<ModelValidationError> Errors { get; set; }

        public bool HasClaim(string claim)
        {
            if (Claims == null) {
                return false;
            }

            foreach(string c in Claims)
            {
                if (c == claim) {
                    return true;
                }
            }

            return false;
        }
    }

    public class RoleValidator : AbstractValidator<Role>
    {
        public RoleValidator()
        {
            RuleFor(role => role.Name).NotEmpty();
        }
    }
}

