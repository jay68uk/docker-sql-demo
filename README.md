# docker-sql-demo
Source code includes the Dockerfile, DockerfileDb and Docker-Compose.yml.
The yml file creates 2 containers, one for the website and one for SQL.
The paths for the projects are specific, anything different and the docker files will need to be amended accordingly.
The 2 images used in the docker files:
  (A). Dockerfile - jaygiles/ddtest:3.0
  (B). DockerfileDb - jaygiles/ddtest_sql
  
1. Unzip the project into C:\dockerdemo_sql
2. Open Visual Studio and build the solution
3. Open Powershell as an administrator and type the following:
  3.1. cd c:\dockerdemo_sql
  3.2. docker-compose up (may take a while to pull the images)
4. Open another Powershell as an administrator and type the following and copy the Ip address: 
  4.1. docker inspect -f='{{range .NetworkSettings.Networks}}{{.IPAddress}}{{end}}'  ddtest_sql
5. Open the webconfig in the DockerDebug project
6. Update the connection string with the Ip address:
   6.1. <connectionStrings>
    <add name="dockerdb" connectionString="Data Source=172.17.131.97,1433;Initial Catalog=DockerTestDb;User         Id=sa;Password=Password_01;MultipleActiveResultSets=True"
         providerName="System.Data.SqlClient" />
  </connectionStrings>
7. Open a browser and type localhost:8080
