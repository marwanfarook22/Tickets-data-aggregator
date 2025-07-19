 # Tickets Data Aggregator 🎫

A C# application to aggregate movie ticket data from PDF files into a single text file, built for the *Ultimate C# Masterclass*! 📄

![Build Status](https://img.shields.io/badge/build-passing-brightgreen)
![License](https://img.shields.io/badge/license-MIT-blue)

## Table of Contents
- [Introduction](#introduction)
- [Features](#features)
- [Technologies](#technologies)
- [Installation](#installation)
- [Usage](#usage)
- [Implementation Details](#implementation-details)
- [Contributing](#contributing)
- [License](#license)

## Introduction
The **Tickets Data Aggregator** is a C# project developed as part of the *Ultimate C# Masterclass* assignment. It processes movie ticket PDFs, extracts key information (title, date, and time), and aggregates the data into a single text file with culture-invariant formatting. Using the PdfPig library, it handles tickets from different regions (e.g., US and Japan) and ensures consistent output. Perfect for learning PDF processing and data aggregation in C#! ✨

 

## Features
- 🎟️ Extracts ticket details (title, date, time) from PDF files
- 📝 Aggregates data into a single `.txt` file with culture-invariant formatting
- 🌐 Supports tickets from different regions (e.g., US: `www.ourCinema.com`, Japan: `.jp`)
- 🔄 Overwrites the output file on each run for fresh results
- 🛠️ Modular design with interfaces for file reading and formatting

## Technologies
This project showcases the following C# technologies:
- **PdfPig Library**: For reading and extracting text from PDF documents.
- **Regular Expressions (Regex)**: To parse ticket details from PDF text.
- **File I/O**: For reading PDF files and writing aggregated data to a text file.
- **Culture-Invariant Formatting**: Ensures consistent date and time formats using `CultureInfo.InvariantCulture`.

## Installation
To get started with the Tickets Data Aggregator, follow these steps:

1. **Clone the repository**:
   ```bash
   git clone https://github.com/username/tickets-data-aggregator.git
   ```
2. **Navigate to the project directory**:
   ```bash
   cd tickets-data-aggregator
   ```
3. **Restore dependencies**: Ensure you have the .NET SDK installed, then run:
   ```bash
   dotnet restore
   ```
4. **Install PdfPig**: Add the PdfPig NuGet package:
   ```bash
   dotnet add package UglyToad.PdfPig
   ```
5. **Build the project**:
   ```bash
   dotnet build
   ```

**Prerequisites**:
- .NET SDK (version 6.0 or higher)
- PdfPig NuGet package
- A C# IDE (e.g., Visual Studio, VS Code, or Rider)
- A folder with sample ticket PDFs (default: `E:\web developing\Backend (C#)\MyWork\Tickets data aggregator\Tickets`)

## Usage
Run the application to aggregate ticket data from PDFs:
```bash
dotnet run
```

The application:
- Reads all `.pdf` files in the specified folder (e.g., `Tickets`).
- Extracts ticket details using regex.
- Writes the aggregated data to `aggregatedTickets.txt` in the same folder.
- Displays the output file path in the console.

**Sample Output (`aggregatedTickets.txt`)**:
```
Star Wars: Episode IV - A New Hope        | 15/05/1977 | 14:30
The Godfather                            | 24/03/1972 | 19:00
```

**Example Code**:
```csharp
var app = new RunAppliction(new FormatingTextFile(), new ReadDirctoryFiles());
app.RunApplictoin();
```

For detailed code, check the `src/` directory.

## Implementation Details
The application processes ticket PDFs and aggregates data as follows:
- **PDF Reading**: Uses the PdfPig library to extract text from PDF files.
- **Data Extraction**: Employs regex to match ticket details (title, date, time) with the pattern:
  ```regex
  Title:(?<title>.+?)Date:(?<date>\d{1,4}/\d{1,2}/\d{2,4})Time:(?<time>\d{1,2}:\d{2}(\s?[APMampm]*)?)
  ```
- **Formatting**: Converts dates and times to invariant culture format (e.g., `d` for dates, empty format for `TimeOnly`).
- **Output**: Writes each ticket’s data as a single line in a `.txt` file, overwriting the file on each run.
- **Modular Design**: Uses interfaces (`IFormatingTextFile`, `IReadDirctoryFiles`) for extensibility.

**Key Classes**:
- `RunAppliction`: Orchestrates the application workflow.
- `FormatingTextFile`: Handles file path construction and text file writing.
- `ReadDirctoryFiles`: Reads PDFs, extracts data, and formats it.

**Note**: The application supports tickets from different regions (e.g., US with `www.ourCinema.com`, Japan with `.jp` domains) by handling varied date/time formats.

## Contributing
We welcome contributions to enhance this ticket aggregator! 🌟 To contribute:
1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Make your changes and commit (`git commit -m "Add your feature"`).
4. Push to your branch (`git push origin feature/your-feature`).
5. Open a pull request.

Please read our [Contributing Guide](CONTRIBUTING.md) for more details.

Have questions or suggestions? Open an [issue](https://github.com/marwanfarook22/tickets-data-aggregator/issues)

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.g README (5).markdown…]()
