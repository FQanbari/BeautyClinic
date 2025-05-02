//using BeautyClinic.API.Features.Appointments.SaveAppointment;
//using Microsoft.EntityFrameworkCore.Metadata;
//using RabbitMQ.Client;
//using RabbitMQ.Client.Events;
//using System.Text;

//namespace BeautyClinic.API.Infrastructure;

//public class AppointmentQueueService
//{
//    private readonly IConnection _connection;
//    private readonly RabbitMQ.Client.IModel _channel;

//    public AppointmentQueueService()
//    {
//        var factory = new ConnectionFactory() { HostName = "localhost" };
//        _connection = factory.CreateConnection();
//        _channel = _connection.CreateModel();

//        _channel.QueueDeclare(queue: "appointments",
//                             durable: true,
//                             exclusive: false,
//                             autoDelete: false,
//                             arguments: null);
//    }

//    public void EnqueueAppointment(SaveAppointmentResponseDto request)
//    {
//        var json = JsonSerializer.Serialize(request);
//        var body = Encoding.UTF8.GetBytes(json);

//        _channel.BasicPublish(exchange: "",
//                             routingKey: "appointments",
//                             basicProperties: null,
//                             body: body);
//    }
//}

//public class Worker : BackgroundService
//{
//    private readonly ILogger<Worker> _logger;
//    private readonly RabbitMQ.Client.IModel _channel;

//    public Worker(ILogger<Worker> logger)
//    {
//        _logger = logger;

//        var factory = new ConnectionFactory() { HostName = "localhost" };
//        var connection = factory.CreateConnection();
//        _channel = connection.CreateModel();

//        _channel.QueueDeclare(queue: "appointments",
//                             durable: true,
//                             exclusive: false,
//                             autoDelete: false,
//                             arguments: null);
//    }

//    protected override Task ExecuteAsync(CancellationToken stoppingToken)
//    {
//        var consumer = new EventingBasicConsumer(_channel);
//        consumer.Received += async (model, ea) =>
//        {
//            var body = ea.Body.ToArray();
//            var json = Encoding.UTF8.GetString(body);
//            var request = JsonSerializer.Deserialize<SaveAppointmentResponseDto>(json);

//            _logger.LogInformation($"درخواست دریافت شد: {request.ProviderId} at {request.AppointmentDateTime}");

//            // پردازش و ذخیره در دیتابیس
//            using var db = new BeautyClinicDbContext(); // اینجا DbContext خودتو بساز و inject کن
//            var exists = await db.Appointments.AnyAsync(a => a.ProviderId == request.ProviderId && a.AppointmentDateTime == request.AppointmentDateTime);

//            if (!exists)
//            {
//                db.Appointments.Add(new Appointment
//                {
//                    ProviderId = request.ProviderId,
//                    AppointmentDateTime = request.AppointmentDateTime,
//                    UserId = request.UserId
//                });

//                await db.SaveChangesAsync();
//                _logger.LogInformation("رزرو موفق ذخیره شد.");
//            }
//            else
//            {
//                _logger.LogWarning("زمان قبلا رزرو شده بود.");
//                // می‌تونی notify یا log بزاری
//            }
//        };

//        _channel.BasicConsume(queue: "appointments",
//                             autoAck: true,
//                             consumer: consumer);

//        return Task.CompletedTask;
//    }
//}