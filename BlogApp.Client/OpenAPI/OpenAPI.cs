
//----------------------
// <auto-generated>
//     Generated REST API Client Code Generator v1.17.0.0 on 19/12/2024 16:02:06
//     Using the tool Refitter v1.4.1
// </auto-generated>
//----------------------



using Refit;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

#nullable enable annotations

namespace BlogApp.Client
{
    [System.CodeDom.Compiler.GeneratedCode("Refitter", "1.4.1.0")]
    internal partial interface IApiClient
    {
        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Success</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Unauthorized</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Not Found</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json, application/problem+json")]
        [Put("/api/posts/{id}")]
        Task<IApiResponse<UpdatePostsResponse>> UpdatePost(string id, [Body, AliasAs("Request")] UpdatePostsRequest request, CancellationToken cancellationToken = default);

        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Success</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Not Found</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json, application/problem+json")]
        [Get("/api/posts/{id}")]
        Task<IApiResponse<GetPostsByIdResponse>> GetPostById(string id, CancellationToken cancellationToken = default);

        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Success</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Unauthorized</description>
        /// </item>
        /// <item>
        /// <term>404</term>
        /// <description>Not Found</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json, application/problem+json")]
        [Delete("/api/posts/{id}")]
        Task<IApiResponse<DeletePostsResponse>> DeletePost(string id, CancellationToken cancellationToken = default);

        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>201</term>
        /// <description>Created</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Unauthorized</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/problem+json")]
        [Post("/api/posts")]
        Task<IApiResponse> InsertPost([Body, AliasAs("Request")] InsertPostsRequest request, CancellationToken cancellationToken = default);

        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Success</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json, application/problem+json")]
        [Get("/api/posts")]
        Task<IApiResponse<GetPostsResponse>> GetPosts([Query, AliasAs("Limit")] int limit, [Query, AliasAs("Offset")] int offset, [Query, AliasAs("Filter")] string? filter = default, [Query, AliasAs("Order")] string? order = default, CancellationToken cancellationToken = default);

        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>204</term>
        /// <description>No Content</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>409</term>
        /// <description>A server side error occurred.</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/problem+json")]
        [Post("/api/authorization/register")]
        Task<IApiResponse> Register([Body, AliasAs("Request")] RegisterRequest request, CancellationToken cancellationToken = default);

        /// <returns>
        /// A <see cref="Task"/> representing the <see cref="IApiResponse"/> instance containing the result:
        /// <list type="table">
        /// <listheader>
        /// <term>Status</term>
        /// <description>Description</description>
        /// </listheader>
        /// <item>
        /// <term>200</term>
        /// <description>Success</description>
        /// </item>
        /// <item>
        /// <term>400</term>
        /// <description>Bad Request</description>
        /// </item>
        /// <item>
        /// <term>401</term>
        /// <description>Unauthorized</description>
        /// </item>
        /// </list>
        /// </returns>
        [Headers("Accept: application/json, application/problem+json")]
        [Post("/api/authorization/login")]
        Task<IApiResponse<LoginResponse>> Login([Body, AliasAs("Request")] LoginRequest request, CancellationToken cancellationToken = default);


    }

}

//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 612 // Disable "CS0612 '...' is obsolete"
#pragma warning disable 649 // Disable "CS0649 Field is never assigned to, and will always have its default value null"
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"
#pragma warning disable 8604 // Disable "CS8604 Possible null reference argument for parameter"
#pragma warning disable 8625 // Disable "CS8625 Cannot convert null literal to non-nullable reference type"
#pragma warning disable 8765 // Disable "CS8765 Nullability of type of parameter doesn't match overridden member (possibly because of nullability attributes)."

namespace BlogApp.Client
{
    using System = global::System;

    

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record UpdatePostsResponse
    {
        [JsonConstructor]

        public UpdatePostsResponse(string @content, System.DateTime? @createdAt, string @id, string @title, System.DateTime? @updatedAt)

        {

            this.Content = @content;

            this.CreatedAt = @createdAt;

            this.Id = @id;

            this.Title = @title;

            this.UpdatedAt = @updatedAt;

        }
        [JsonPropertyName("content")]
        public string Content { get; init; }

        [JsonPropertyName("createdAt")]
        public System.DateTime? CreatedAt { get; init; }

        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("updatedAt")]
        public System.DateTime? UpdatedAt { get; init; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record MicrosoftAspNetCoreMvcProblemDetails
    {
        [JsonConstructor]

        public MicrosoftAspNetCoreMvcProblemDetails(string @detail, string @instance, int? @status, string @title, string @type)

        {

            this.Type = @type;

            this.Title = @title;

            this.Status = @status;

            this.Detail = @detail;

            this.Instance = @instance;

        }
        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("status")]
        public int? Status { get; init; }

        [JsonPropertyName("detail")]
        public string Detail { get; init; }

        [JsonPropertyName("instance")]
        public string Instance { get; init; }

        private IDictionary<string, object> _additionalProperties;

        [JsonExtensionData]
        public IDictionary<string, object> AdditionalProperties
        {
            get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
            set { _additionalProperties = value; }
        }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record UpdatePostsRequest
    {
        [JsonConstructor]

        public UpdatePostsRequest(string @content, string @title)

        {

            this.Content = @content;

            this.Title = @title;

        }
        [JsonPropertyName("content")]
        public string Content { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

    }

    /// <summary>
    /// RFC7807 compatible problem details/ error response class. this can be used by configuring startup like so:
    /// <br/>
    /// <br/>    app.UseFastEndpoints(x =&gt; x.Errors.ResponseBuilder = ProblemDetails.ResponseBuilder);
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record FastEndpointsProblemDetails
    {
        [JsonConstructor]

        public FastEndpointsProblemDetails(string @detail, ICollection<FastEndpointsProblemDetails_Error> @errors, string @instance, int? @status, string @title, string @traceId, string @type)

        {

            this.Type = @type;

            this.Title = @title;

            this.Status = @status;

            this.Instance = @instance;

            this.TraceId = @traceId;

            this.Detail = @detail;

            this.Errors = @errors;

        }
        [JsonPropertyName("type")]
        public string Type { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("status")]
        public int? Status { get; init; }

        [JsonPropertyName("instance")]
        public string Instance { get; init; }

        [JsonPropertyName("traceId")]
        public string TraceId { get; init; }

        /// <summary>
        /// the details of the error
        /// </summary>

        [JsonPropertyName("detail")]
        public string Detail { get; init; }

        [JsonPropertyName("errors")]
        public ICollection<FastEndpointsProblemDetails_Error> Errors { get; init; }

    }

    /// <summary>
    /// the error details object
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record FastEndpointsProblemDetails_Error
    {
        [JsonConstructor]

        public FastEndpointsProblemDetails_Error(string @code, string @name, string @reason, string @severity)

        {

            this.Name = @name;

            this.Reason = @reason;

            this.Code = @code;

            this.Severity = @severity;

        }    /// <summary>
        /// the name of the error or property of the dto that caused the error
        /// </summary>

        [JsonPropertyName("name")]
        public string Name { get; init; }

        /// <summary>
        /// the reason for the error
        /// </summary>

        [JsonPropertyName("reason")]
        public string Reason { get; init; }

        /// <summary>
        /// the code of the error
        /// </summary>

        [JsonPropertyName("code")]
        public string Code { get; init; }

        /// <summary>
        /// the severity of the error
        /// </summary>

        [JsonPropertyName("severity")]
        public string Severity { get; init; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record InsertPostsRequest
    {
        [JsonConstructor]

        public InsertPostsRequest(string @content, string @title)

        {

            this.Content = @content;

            this.Title = @title;

        }
        [JsonPropertyName("content")]
        [System.ComponentModel.DataAnnotations.Required]
        public string Content { get; init; }

        [JsonPropertyName("title")]
        [System.ComponentModel.DataAnnotations.Required]
        public string Title { get; init; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record GetPostsResponse
    {
        [JsonConstructor]

        public GetPostsResponse(ICollection<GetPostsResponse_Post> @posts, int? @totalItems)

        {

            this.Posts = @posts;

            this.TotalItems = @totalItems;

        }
        [JsonPropertyName("posts")]
        public ICollection<GetPostsResponse_Post> Posts { get; init; }

        [JsonPropertyName("totalItems")]
        public int? TotalItems { get; init; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record GetPostsResponse_Post
    {
        [JsonConstructor]

        public GetPostsResponse_Post(string @content, System.DateTime? @createdAt, string @id, string @title, System.DateTime? @updatedAt, GetPostsResponse_User @user)

        {

            this.Content = @content;

            this.CreatedAt = @createdAt;

            this.Id = @id;

            this.Title = @title;

            this.UpdatedAt = @updatedAt;

            this.User = @user;

        }
        [JsonPropertyName("content")]
        public string Content { get; init; }

        [JsonPropertyName("createdAt")]
        public System.DateTime? CreatedAt { get; init; }

        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("updatedAt")]
        public System.DateTime? UpdatedAt { get; init; }

        [JsonPropertyName("user")]
        public GetPostsResponse_User User { get; init; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record GetPostsResponse_User
    {
        [JsonConstructor]

        public GetPostsResponse_User(string @email, string @id)

        {

            this.Email = @email;

            this.Id = @id;

        }
        [JsonPropertyName("email")]
        public string Email { get; init; }

        [JsonPropertyName("id")]
        public string Id { get; init; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record GetPostsRequest
    {
        [JsonConstructor]

        public GetPostsRequest()

        {

        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record GetPostsByIdResponse
    {
        [JsonConstructor]

        public GetPostsByIdResponse(string @content, System.DateTime? @createdAt, string @id, string @title, System.DateTime? @updatedAt)

        {

            this.Content = @content;

            this.CreatedAt = @createdAt;

            this.Id = @id;

            this.Title = @title;

            this.UpdatedAt = @updatedAt;

        }
        [JsonPropertyName("content")]
        public string Content { get; init; }

        [JsonPropertyName("createdAt")]
        public System.DateTime? CreatedAt { get; init; }

        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("updatedAt")]
        public System.DateTime? UpdatedAt { get; init; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record GetPostsByIdRequest
    {
        [JsonConstructor]

        public GetPostsByIdRequest()

        {

        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record DeletePostsResponse
    {
        [JsonConstructor]

        public DeletePostsResponse(string @content, System.DateTime? @createdAt, string @id, string @title, System.DateTime? @updatedAt)

        {

            this.Content = @content;

            this.CreatedAt = @createdAt;

            this.Id = @id;

            this.Title = @title;

            this.UpdatedAt = @updatedAt;

        }
        [JsonPropertyName("content")]
        public string Content { get; init; }

        [JsonPropertyName("createdAt")]
        public System.DateTime? CreatedAt { get; init; }

        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("title")]
        public string Title { get; init; }

        [JsonPropertyName("updatedAt")]
        public System.DateTime? UpdatedAt { get; init; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record DeletePostsRequest
    {
        [JsonConstructor]

        public DeletePostsRequest()

        {

        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record RegisterRequest
    {
        [JsonConstructor]

        public RegisterRequest(string @email, string @password)

        {

            this.Email = @email;

            this.Password = @password;

        }
        [JsonPropertyName("email")]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^[^@]+@[^@]+$")]
        public string Email { get; init; }

        [JsonPropertyName("password")]
        [System.ComponentModel.DataAnnotations.Required]
        public string Password { get; init; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record LoginResponse
    {
        [JsonConstructor]

        public LoginResponse(string @email, string @id, string @token)

        {

            this.Id = @id;

            this.Email = @email;

            this.Token = @token;

        }
        [JsonPropertyName("id")]
        public string Id { get; init; }

        [JsonPropertyName("email")]
        public string Email { get; init; }

        [JsonPropertyName("token")]
        public string Token { get; init; }

    }

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "14.2.0.0 (NJsonSchema v11.1.0.0 (Newtonsoft.Json v13.0.3.0))")]
    internal partial record LoginRequest
    {
        [JsonConstructor]

        public LoginRequest(string @email, string @password)

        {

            this.Email = @email;

            this.Password = @password;

        }
        [JsonPropertyName("email")]
        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DataAnnotations.RegularExpression(@"^[^@]+@[^@]+$")]
        public string Email { get; init; }

        [JsonPropertyName("password")]
        [System.ComponentModel.DataAnnotations.Required]
        public string Password { get; init; }

    }


}

#pragma warning restore  108
#pragma warning restore  114
#pragma warning restore  472
#pragma warning restore  612
#pragma warning restore 1573
#pragma warning restore 1591
#pragma warning restore 8073
#pragma warning restore 3016
#pragma warning restore 8603
#pragma warning restore 8604
#pragma warning restore 8625