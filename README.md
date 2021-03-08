
# M&G Case Study Applicaiton
===================


### Introduction
This is a sample application build to validate sedol string on certain rules.


### Projects
* SEDOL - Intepedent project which can be consumed in other application in form of liberary or project. This liberary expose SedolValidator which can be consumed to validate SEDOL with ValidateSedol method.
* SEDOLConsole - Dummy Console application which is being setup to get user input for SEDOL and return validation output. Type Exit to exit console
* SEDOLTest - Unit test project for SEDOL class liberary project. Contains UT methods for SEDOL classes

### Technologies
SEDOL is based on .NET Framework 4.7.2 with Csharp 7


### Launch/Setup
By default SEDOLConsole is set as startup otherwise please set SEDOLConsole as startup and run the application.
This will launch a console window where user can key in SEDOL and it will return the output in format of 

```swift
  InputString Test Value|IsValidSedol|IsUserDefined|ValidationDetails
```

### Integration
Developer can integration SEDOL project(liberary) to any .NET application which supports (.NET Framework 4.7.2) and can invoke the validator. 
Integrating this liberary will expose SedolValidator class which contains method ValidateSedol. This method will return the output in form of ISedolValidationResult type

*Example*

			ISedolValidationResult result = new SedolValidator().ValidateSedol(sedol);

Return type ISedolValidationResult containts the below properties

    string InputString 
    bool IsValidSedol 
    bool IsUserDefined
    string ValidationDetails

### Validation Rules

Below are the rules on whihc the validation will occur and get the output in following format.

    Rule1 -  Null, empty string or string other than 7 characters long
    Null|False|False|Input string was not 7-characters long

    Rule2 - Invalid Checksum non user defined SEDOL
    1234567|False|False|Checksum digit does not agree with the rest of the input

    Rule3 -  Valid non user define SEDOL
    0709954|True|False|Null

    Rule4 - Invalid Checksum user defined SEDOL
    9123451|False|True|Checksum digit does not agree with the rest of the input

    Rule5 - Invaid characters found
    VA.CDE8|False|False|SEDOL contains invalid characters

    Rule6 - Valid user defined SEDOL
    9123458|True|True|Null

### Example
```swift
     ISedolValidationResult result = new SedolValidator().ValidateSedol("1234567");
     Output in form of - InputString Test Value|IsValidSedol|IsUserDefined|ValidationDetails
     1234567|False|False|Checksum digit does not agree with the rest of the input
```