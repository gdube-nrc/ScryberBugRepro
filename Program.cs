using Scryber.Components;
using ScryberRepro.Models;
using Path = System.IO.Path;

var model = new CatalogPdfDocument {
    ShowPrices = true,
    Header = new CatalogPdfHeader {
        LogoPath = "",
        SerialNumber = "SN-2024-00123",
        ProductNumber = "EDB-456789",
        ProductModel = "HydroMax 3000",
        ProductFamily = "Hydraulic Cranes",
        ProductType = "Heavy Duty",
        Currency = "USD"
    },
    Labels = new CatalogPdfLabels {
        SerialNumber = "Serial Number",
        TableOfContents = "Table of Contents",
        Balloon = "Bal.",
        PartNumber = "Part #",
        Description = "Description",
        Quantity = "Qty",
        Weight = "Weight",
        Price = "Price"
    },
    Assemblies = [
        new CatalogPdfAssemblySection {
            AnchorId = "asm-main",
            Title = "EDB-456789 - Main Hydraulic Assembly",
            ImageFilePath = Path.Combine(AppContext.BaseDirectory, "images", "assembly.jpg"),
            Parts = [
                new() { Balloon = "1",  PartNumber = "HYD-001", Description = "Hydraulic Cylinder - 3\" Bore",     Quantity = "2",  Weight = "12.50 kg", Price = "450.00" },
                new() { Balloon = "2",  PartNumber = "HYD-002", Description = "Pressure Relief Valve",             Quantity = "1",  Weight = "0.80 kg",  Price = "125.50" },
                new() { Balloon = "3",  PartNumber = "HYD-003", Description = "High Pressure Hose Assembly - 6ft", Quantity = "4",  Weight = "2.10 kg",  Price = "89.99"  },
                new() { Balloon = "4",  PartNumber = "HYD-004", Description = "Mounting Bracket - Heavy Duty",     Quantity = "2",  Weight = "3.40 kg",  Price = "67.25"  },
                new() { Balloon = "5",  PartNumber = "HYD-005", Description = "O-Ring Kit - Viton",                Quantity = "1",  Weight = "0.10 kg",  Price = "22.00"  },
                new() { Balloon = "6",  PartNumber = "STR-010", Description = "Structural Support Beam",           Quantity = "1",  Weight = "18.00 kg", Price = "320.00" },
                new() { Balloon = "7",  PartNumber = "ELC-020", Description = "Solenoid Valve - 24V DC",           Quantity = "2",  Weight = "1.20 kg",  Price = "195.75" },
                new() { Balloon = "8",  PartNumber = "FAS-030", Description = "Hex Bolt M12x40 Grade 10.9",        Quantity = "16", Weight = "0.05 kg",  Price = "1.50"   },
            ]
        }
    ]
};

// Resolve template path
var templatePath = Path.Combine(AppContext.BaseDirectory, "Templates", "CatalogSingle.html");
if (!File.Exists(templatePath)) {
    Console.Error.WriteLine($"Template not found: {templatePath}");
    return 1;
}

// Check image file exists
var imagePath = model.Assemblies[0].ImageFilePath;
if (!File.Exists(imagePath)) {
    Console.WriteLine($"WARNING: Image not found at {imagePath}");
    Console.WriteLine("Place an image file at images/assembly.jpg and rebuild.");
}

// Parse template and generate PDF (mirrors GeneratePartialCatalogPdfAsync)
using var doc = Document.ParseDocument(templatePath);
doc.Info.Title = $"{model.Header.SerialNumber} - Scryber CSS Image Sizing Repro";
doc.Info.Author = "ScryberRepro";

doc.Params["model"] = model;

var outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.pdf");
using (var stream = File.Create(outputPath)) {
    doc.SaveAsPDF(stream);
}

Console.WriteLine($"PDF generated: {outputPath}");
return 0;
