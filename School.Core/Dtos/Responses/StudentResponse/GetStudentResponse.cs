﻿namespace School.Core.Dtos.Responses.StudentReponse
{
    public class GetStudentResponse
    {



        public string? Name { get; set; } = string.Empty;

        public string? Address { get; set; } = string.Empty;

        public string? Phone { get; set; } = string.Empty;


        public string? DepartmentName { get; set; } = string.Empty!;
    }
}
