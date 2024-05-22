## Deep Copy Benchmark

This project compares the speed of different deep copy methods in C#.

**Methods:**
* AutoMapper
* DeepCloner
* Newtonsoft.Json
* System.Text.Json
* MessagePack

### Benchmark Result
See which method wins the copy race!
![Screenshot 2024-05-22 155324](https://github.com/arahimi71/DeepCopyBenchmark/assets/60326788/c29845b6-b613-42a3-9406-7057a838769e)

**Run the Benchmark:**
1. Install .NET Core SDK & BenchmarkDotNet.
2. Run `dotnet run -c Release` in the project directory.

**Adjust the Test:**
Change `NumberOfCompanies` to test with different data sizes.
