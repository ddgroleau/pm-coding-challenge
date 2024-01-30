using System.Text.Json;
using Application.Dto;

namespace Tests.Data;

public class MockData
{
    public static IEnumerable<OrganizationDto> MockOrganizationDtos()
    {
        const string data =
            @"[{""id"":1,""createdAt"":""2021-04-19T13:45:37.621Z"",""name"":""Mrs. Sasha Jakubowski""},{""id"":2,""createdAt"":""2021-04-19T09:19:17.052Z"",""name"":""Bud Heller""},{""id"":3,""createdAt"":""2021-04-19T14:07:35.169Z"",""name"":""Blaze Goodwin""},{""id"":4,""createdAt"":""2021-04-19T04:50:25.350Z"",""name"":""Ryleigh Harber""},{""id"":5,""createdAt"":""2021-04-19T04:31:36.378Z"",""name"":""Juliana Auer PhD""},{""id"":6,""createdAt"":""2021-04-19T12:01:25.536Z"",""name"":""Vernie Weissnat Sr.""},{""id"":7,""createdAt"":""2021-04-18T19:38:18.415Z"",""name"":""Sarah Rohan""},{""id"":8,""createdAt"":""2021-04-19T08:49:42.265Z"",""name"":""Reece Barrows""}]";
        return JsonSerializer.Deserialize<OrganizationDto[]>(data) ?? Enumerable.Empty<OrganizationDto>();
    }
    
    public static IEnumerable<UserDto> MockUserDtos()
    {
        const string data =
                @"[{""id"":1,""organizationId"":1,""createdAt"":""2021-04-18T22:27:37.490Z"",""name"":""Bertha Turner"",""avatar"":""https://s3.amazonaws.com/uifaces/faces/twitter/sunlandictwin/128.jpg""}]";
        return JsonSerializer.Deserialize<UserDto[]>(data) ?? Enumerable.Empty<UserDto>();
    }
    
    public static IEnumerable<PhoneDto> MockPhoneDtos()
    {
        const string data =
            @"[{""id"":1,""userId"":1,""createdAt"":""2021-04-19T16:27:55.026Z"",""name"":""Dejuan Upton MD"",""blacklisted"":false},{""id"":2,""userId"":1,""createdAt"":""2021-04-19T16:27:55.026Z"",""name"":""Test Phone 2"",""blacklisted"":true},{""id"":3,""userId"":1,""createdAt"":""2021-04-19T16:27:55.026Z"",""name"":""Test Phone 3"",""blacklisted"":true}]";
        return JsonSerializer.Deserialize<PhoneDto[]>(data) ?? Enumerable.Empty<PhoneDto>();
    }
}