# Unicorn: a PDF writing library
Welcome to Unicorn!

Are you a .NET developer?  Need to write PDF output?  Finding the existing PDF output libraries for .NET difficult to use, expensive or both?  
You have come to the right place.

Unicorn is a free, open-source library for writing PDF files in a way that should be simple and straightforward for developers.  It currently supports:

- The PDF "standard fonts" that all PDF readers should implement.
- Embedding TrueType/OpenType fonts
- Line drawing
- Text
- Embedding JPEG images
- Data compression

Unicorn can flow your text for you, or you can manually position it, according to need.

At present Unicorn is alpha-quality software, but is being worked on to improve its feature set.

## How to use Unicorn

1. Reference the `Unicorn` package in your project via NuGet.
1. Decide what font support you need, and reference the appropriate packages for that (see below).
1. In your code, create a `PdfDocument` object and use the `AppendPage()` method to add a page to it.
1. Add content to your page
1. Call `PdfDocument.WriteAsync()` to write the PDF data to a stream.

It's that simple.  Read the Getting Started guide for the details of step 4.  Or, look at the example projects.  `Unicorn.TextConvert` is is a simple command-line text-to-PDF
converter that loads a plain text file and outputs a typeset PDF, with command-line options to set the font and the text colour.  The project code should give you
a good idea how to use fonts, embed them in a document, and add free-flowing text to a page.  `Unicorn.ImageConvert` is a simple command-line program that creates 
a PDF that contains a set of JPEG images.

## Font handling

In order to lay out the text of a PDF document correctly, Unicorn needs to be able to accurately measure the text.  Because of this, our font-handling code has been
split into different packages so that your app doesn't need to bundle unnecessary code.

- If you want to use the PDF standard fonts that all readers should support, reference the `Unicorn.FontTools.StandardFonts` package.
- If you want to use TrueType or OpenType fonts in your documents, reference the `Unicorn.FontTools` package.

The two packages are complementary, and you can reference both should you need to use both.  The `Unicorn.FontTools.StandardFonts` package is relatively large as it
contains all of the metric data for the standard fonts, so that's why this package has been made optional.  The `Unicorn.FontTools` package extracts the required metrics from OpenType
or TrueType font files.  It can be used to create PDF files that reference non-embedded fonts, or to embed OpenType and TrueType fonts into PDF files.  However, note that
Unicorn will refuse to embed a font file if its font foundry has specified in the font that embedding is not permitted.  Referenced but non-embedded fonts must 
be installed on the readers' devices in order for the file to appear as expected.

## Future plans
Unicorn features under development include:

- Embedding other image formats, such as BMP and PNG.
- Filled shapes
- Filled and outline text
- CID font support
- Better support for OpenType kerning and ligatures
- Parsing existing PDF files and adding to them
