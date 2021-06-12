# EncodingTests

![dotnet-ubuntu.yml](https://github.com/benrobot/EncodingTests/actions/workflows/dotnet-ubuntu.yml/badge.svg)
![dotnet-windows.yml](https://github.com/benrobot/EncodingTests/actions/workflows/dotnet-windows.yml/badge.svg)


**BEWARE** the file encoding

This project was created in preparation for asking a question on Stackoverflow (https://stackoverflow.com/q/67950751/3166133)

# Problem
On a private project I had a unit test that passed on Windows and failed on Linux. I narrowed it down to an issue with encoding U+2019 `’` RIGHT SINGLE QUOTATION MARK.

On Windows, calling `System.Text.Encoding.UTF8.GetBytes("’")` resulted in the correct 3 bytes (`0xE2, 0x80, 0x99`) but on Linux (tested on Ubuntu) the
result bytes correspond to � (`0xEF, 0xBF, 0xBD`).

# Cause
The .cs file where my code had the `’` was ANSI (Windows-1252) encoded.

# Fix
Convert my ANSI (Windows-1252) encoded files to 
