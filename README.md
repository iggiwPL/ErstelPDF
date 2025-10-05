# ErstelPDF Library

## Shortcuts of versions

**ind** - In Development

## Description

The ErstelPDF is a designed library with a small size to create PDF Files. The name of the library came from the German word "Erstellen" that means "create" and also PDF. Name just means "Create a PDF". This will be only for testing and analysis purposes. The library uses a 1.0 PDF version because the money costs for buying a specification PDF 2.0. Also planned is to put AI features based on edge computing to preprocess using the ONNX pretrained models that run locally on machines.

## Standards

- Every public method of the API must have handling exceptions.
- Thread safe.
- Unit testing.
- Enterprise grade.

## Goals

- **v.0.0.1ind** - Create an empty PDF with stacks with only header. | Done
- **v.0.0.2ind** - Create a dictionary syntax for generating an empty page of PDF. | Done
- **v.0.0.3ind** - Generate an empty PDF page and unify the datatypes Queues. | Done
- **v.0.0.4ind** - Cover with unit tests. | Done
- **v.0.0.5ind** - Identical with previous version and make it thread safe. Made this function for creating PDF self-contained by idea every thread = PDF file | Done
- **v.0.0.6ind** - Make it modular. | Done
- **v.0.0.7ind** - Improve the paralellisation of generating PDF by applying both: sequental and parallel using max 2 threads
### Note: Delayed because I learn math for AI so I don't have any time to carry out new improvements. Also my school plan is my constrain.

## Namespaces functionalities

**ErstelPDF.Core** - The kernel of the library where base classes will be defined for example file creating and binary appending - extended version of "BinaryWriter".

**ErstelPDF.Dictionary** - This is a dictionary of the library where patterns of the objects with syntax of the format will be stored.

**ErstelPDF.Stacks** - This namespace has queue document objects that are added dynamically.

**ErstelPDF.Transforms** - The part of the library performs all transformations for example generating an "xref" table and a "trailer" for PDFs.

**ErstelPDF.DataTypes** - The namespace is designed to "unify" data types of PDF operations to prevent other libraries from colliding.
