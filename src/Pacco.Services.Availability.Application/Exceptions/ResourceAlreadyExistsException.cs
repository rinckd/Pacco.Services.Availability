using System;

namespace Pacco.Services.Availability.Application.Exceptions
{
    public class ResourceAlreadyExistsException : AppException
    {
        public Guid Id { get; }

        public ResourceAlreadyExistsException(Guid id) : base($"Resource with ID: '{id}' already exists")
        {
            Id = id;
        }
    }
}