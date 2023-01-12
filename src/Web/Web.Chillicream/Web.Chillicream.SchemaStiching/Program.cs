using System.Net.Http.Headers;

using DotnetExploration.Web.Chillicream.SchemaStitching.Common;
using DotnetExploration.Web.Chillicream.SchemaStitching.Github.Types;

var builder = WebApplication.CreateBuilder(args);

// Register HttpClient used by HotChocolate to stitch Githubs schema
builder.Services
    .AddHttpClient(WellKnownSchemaName.Github, c =>
    {
        c.BaseAddress = new Uri("https://api.github.com/graphql");
        c.DefaultRequestHeaders.Add("Authorization", $"bearer {builder.Configuration.GetConnectionString("GithubToken")}");
        c.DefaultRequestHeaders.Add("Accept", "application/json");

        // User-agent is required, otherwise you're going to be hit with a 403
        c.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Web.Chillicream.Schemastiching.example", "0.1"));
    });

// Register Hotchocolate GraphQL server with types
builder.Services
    .AddGraphQLServer()
    .AddRemoteSchema(WellKnownSchemaName.Github)
        .AddType<GitObjectIDType>()
        .AddType<URIType>()
        .AddType<PreciseDateTimeType>()
        .AddType<Base64StringType>()
        .AddType<HTMLType>()
        .AddType<X509CertificateType>()
        .AddType<GitTimestampType>()
        .AddType<GitSSHRemoteType>();

// We have to specifically add types for named schema, otherwise
// hotchocolate won't know were they belong to.
builder.Services
    .AddGraphQL(WellKnownSchemaName.Github)
        .AddType<GitObjectIDType>()
        .AddType<URIType>()
        .AddType<PreciseDateTimeType>()
        .AddType<Base64StringType>()
        .AddType<HTMLType>()
        .AddType<X509CertificateType>()
        .AddType<GitTimestampType>()
        .AddType<GitSSHRemoteType>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
