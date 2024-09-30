﻿using Appointments.Domain.Models;
using System.Text.Json.Serialization;

namespace Appointments.Application.MediatR.Responses.UserReponses
{
    public class GetAllUsersByFilterResponse : MediatRBaseResponse
    {
        [JsonPropertyName("users")]
        public List<User> Users { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
