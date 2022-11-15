using ChatApp.Business.Concrete;
using ChatApp.DataLayer;
using ChatApp.DataLayer.Entity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ChatApplicationContext>();
builder.Services.AddScoped<DalUser>();
builder.Services.AddScoped<UserManager>();

builder.Services.AddScoped<ChatApplicationContext>();
builder.Services.AddScoped<DalFriend>();
builder.Services.AddScoped<FriendManager>();

builder.Services.AddScoped<ChatApplicationContext>();
builder.Services.AddScoped<DalGroup>();
builder.Services.AddScoped<GroupManager>();

builder.Services.AddScoped<ChatApplicationContext>();
builder.Services.AddScoped<DalGroupMember>();
builder.Services.AddScoped<GroupMemberManager>();

builder.Services.AddScoped<ChatApplicationContext>();
builder.Services.AddScoped<DalMessage>();
builder.Services.AddScoped<MessageManager>();

builder.Services.AddScoped<ChatApplicationContext>();
builder.Services.AddScoped<DalComplain>();
builder.Services.AddScoped<ComplainManager>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsAllowAll",
        builder =>
        {
            builder.AllowAnyMethod().
            AllowAnyOrigin().
            AllowAnyHeader().
            AllowAnyMethod().
            SetIsOriginAllowed(origin => true);
        });
});

var app = builder.Build();
app.UseCors("CorsAllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
