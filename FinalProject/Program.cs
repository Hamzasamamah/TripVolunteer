using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using LearningHub.Infra.Repository;
using LearningHub.Infra.Services;
using LearningHub.Core.Common;
using LearningHub.Core.Repository;
using LearningHub.Core.Services;
using LearningHub.Infra.Common;
using LearningHub.Infra.Repository;
using LearningHub.Infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DinkToPdf;
using DinkToPdf.Contracts;


var builder = WebApplication.CreateBuilder(args);
var emailSettings = builder.Configuration.GetSection("EmailSettings");
var smtpHost = emailSettings["SMTPHost"];
var smtpPort = int.Parse(emailSettings["SMTPPort"]);
var email = emailSettings["Email"];
var password = emailSettings["Password"];
string wkhtmltopdfPath = "C:\\Users\\User\\Desktop\\FinalProject\\FinalProject\\bin\\Debug\\net6.0\\runtimes\\win-x86\\native";
Environment.SetEnvironmentVariable("WKHTMLTOPDF_PATH", wkhtmltopdfPath);


// Add services to the container.
builder.Services.AddCors(corsOptions =>
{
    corsOptions.AddPolicy("policy", builder =>
    { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbContext, DBContext>();

builder.Services.AddScoped<IFinalInvoiceService, FinalInvoiceService>();
builder.Services.AddScoped<IFinalGalleryService, FinalGalleryService>();
builder.Services.AddScoped<IFinalTripService, FinalTripService>();
builder.Services.AddScoped<IFinalUserTripService, FinalUserTripService>();
builder.Services.AddScoped<IFinalVolunteerService, FinalVolunteerService>();
//obaida 
builder.Services.AddScoped<IFinalAboutUsService, FinalAboutUsService>();
builder.Services.AddScoped<IFinalContactUsService, FinalContactUsService>();
builder.Services.AddScoped<IFinalHomeService, FinalHomeService>();
builder.Services.AddScoped<IFinalTestimonialService, FinalTestimonialService>();
builder.Services.AddScoped<IFinalUserRoleService, FinalUserRoleService>();
//hamza
builder.Services.AddScoped<IFinalUserService, FinalUserService>();
builder.Services.AddScoped<IFinalCategoryService, FinalCategoryService>();
builder.Services.AddScoped<IFinalPaymentService, FinalPaymentService>();
builder.Services.AddScoped<IFinalVisacardService, FinalVisacardService>();
builder.Services.AddScoped<IFinalReviewService, FinalReviewService>();
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));


builder.Services.AddTransient<IEmailService, EmailService>(provider =>
    new EmailService(smtpHost, smtpPort, email, password));

builder.Services.AddScoped<IFinalTripRepository, FinalTripRepository>();
builder.Services.AddScoped<IFinalInvoiceRepository, FinalInvoiceRepository>();
builder.Services.AddScoped<IFinalGalleryRepository, FinalGalleryRepository>();
builder.Services.AddScoped<IFinalUserTripRepository, FinalUserTripRepository>();
builder.Services.AddScoped<IFinalVolunteerRepository, FinalVolunteerRepository>();
//obaida 
builder.Services.AddScoped<IFinalAboutUsRepository, FinalAboutUsRepository>();
builder.Services.AddScoped<IFinalContactUsRepository, FinalContactUsRepository>();
builder.Services.AddScoped<IFinalHomeRepository, FinalHomeRepository>();
builder.Services.AddScoped<IFinalTestimonialRepository, FinalTestimonialRepository>();
builder.Services.AddScoped<IFinalUserRoleRepository, FinalUserRoleRepository>();
builder.Services.AddScoped<IFinalReviewRepository, FinalReviewRepository>();

//hamza
builder.Services.AddScoped<IFinalUserRepository, FinalUserRepository>();
builder.Services.AddScoped<IFinalCategoryRepository, FinalCategoryRepository>();
builder.Services.AddScoped<IFinalPaymentRepository, FinalPaymentRepository>();
builder.Services.AddScoped<IFinalVisacardRepository, FinalVisacardRepository>();

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
   .AddJwtBearer(options =>
   {
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidateAudience = true,
           ValidateLifetime = true,
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HelloTraineesinwebapicourse@34567"))
       };
   });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("policy");

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
