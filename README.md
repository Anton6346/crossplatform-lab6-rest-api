Laboratory Work 6
Code Quality Assessment, OpenTelemetry, Tracing & Load Testing
 General Information

Discipline: Software Engineering / Web Technologies
Laboratory work: №6
Topic: Code quality assessment, OpenTelemetry, distributed tracing, load and security testing
Technology stack:

ASP.NET Core Web API / MVC

Entity Framework Core

MS SQL Server

OpenTelemetry

Zipkin, Prometheus, Grafana

ElasticSearch

SonarQube

JMeter, InfluxDB

OWASP ZAP

Docker, docker-compose

 Purpose of the work

The purpose of this laboratory work is to:

assess the quality of software code using SonarQube

integrate OpenTelemetry into previously developed applications (LW4, LW5)

collect and visualize metrics, traces, and logs

perform load testing with different numbers of concurrent users

identify performance bottlenecks and propose optimization methods

conduct security testing using OWASP ZAP

demonstrate observability tools in a distributed system

 Project Structure
Solution
│
├── WebApi (LW4 / LW5)
│   ├── Controllers
│   ├── Models
│   ├── Data
│   ├── Program.cs
│   └── appsettings.json
│
├── SeedConsoleApp
│   ├── Program.cs
│   ├── Models
│   └── Data
│
├── docker
│   ├── docker-compose.yml
│   ├── prometheus.yml
│   └── otel-collector-config.yml
│
├── jmeter
│   ├── load_test.jmx
│   └── results
│
├── reports
│   ├── sonar-report.pdf
│   ├── zap-report.html
│   └── load-test-results.pdf
│
└── README.md

1️ Code Quality Assessment (SonarQube)

SonarQube was used to analyze the code quality of the Web API application.

The following metrics were evaluated:

Code smells

Bugs

Vulnerabilities

Maintainability

Duplication

Analysis results are saved in the /reports directory.

📎 Result:
The code meets basic quality requirements, minor code smells were detected and fixed.

2️ OpenTelemetry Integration
Integrated into:

Laboratory Work 4 (Web API)

Laboratory Work 5 (Versioned REST API)

Collected data:

HTTP request duration

Distributed traces

Dependency graph

Garbage Collector metrics

Heap size

CPU and memory usage

Tools used:

OpenTelemetry SDK

Prometheus

Grafana

Zipkin

ElasticSearch

3️ Additional Tracing Features
✔ Additional span

A simulated long-running process was added to demonstrate tracing of slow operations.

✔ Custom attributes

Additional span attributes were added:

requestId

userAgent

entityCount

operationType

This allows better trace analysis and debugging.

4️ Database Seeding (X > 10000)

To perform realistic load testing, the database was populated with test data.

Method:

A separate Console Application (SeedConsoleApp) was created.

Result:

15,000 records were added to the Courses table.

Example code:
for (int i = 0; i < 15000; i++)
{
    context.Courses.Add(new Course
    {
        Name = "Course " + i,
        Hours = i % 100
    });
}
context.SaveChanges();

5️ Load Testing
Tools:

Apache JMeter

InfluxDB

Grafana

Test scenarios:

The system was tested with:

1 user

5 users

20 users

50 users

100 users

300 users

Metrics evaluated:

Response time

Error rate

Throughput

Findings:

Response time increases approximately linearly with user count.

Bottlenecks were detected in database access logic.

6️ Performance Analysis

Using Zipkin + Grafana + Prometheus, the slowest parts of the application were identified.

Slowest component:

Database queries without pagination and caching.

Proposed optimization:

Add pagination

Introduce caching

Optimize SQL queries

Use asynchronous processing

7️ Security Testing (OWASP ZAP)

Security testing was performed using OWASP ZAP.

Automated scan was executed against the Web API.

Findings include:

Missing security headers

Minor configuration issues

 Report: Available in /reports/zap-report.html

8️ Docker & Deployment

All observability tools were deployed using docker-compose.

The application was successfully run on:

Windows

Linux

Docker configuration files are located in the /docker directory.

 Repository Content

The repository includes:

Source code

Docker configuration files

Load testing scripts

SonarQube and OWASP ZAP reports

Documentation

✅ Conclusion

All tasks of Laboratory Work 6 were successfully completed:

Code quality assessment

Observability integration

Load testing

Performance analysis

Security testing

The system demonstrates stable behavior under load and provides full observability support.

📎 How to Run

Start infrastructure:

docker-compose up -d


Run Web API:

dotnet run


Seed database:

dotnet run --project SeedConsoleApp


Run JMeter tests and view results in Grafana.

🧑‍💻 Author

Student: ( Anton )
Group: ( 32 )
Year: 2026
