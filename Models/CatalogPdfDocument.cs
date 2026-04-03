namespace ScryberRepro.Models;

public class CatalogPdfDocument {
    public CatalogPdfHeader Header { get; set; } = new();
    public CatalogPdfLabels Labels { get; set; } = new();
    public List<CatalogPdfTocItem> TableOfContents { get; set; } = new();
    public List<CatalogPdfAssemblySection> Assemblies { get; set; } = new();
    public bool ShowPrices { get; set; } = true;
}

public class CatalogPdfLabels {
    public string SerialNumber { get; set; } = string.Empty;
    public string TableOfContents { get; set; } = string.Empty;
    public string Balloon { get; set; } = string.Empty;
    public string PartNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
    public string Weight { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
}

public class CatalogPdfHeader {
    public string LogoPath { get; set; } = string.Empty;
    public string SerialNumber { get; set; } = string.Empty;
    public string ProductModel { get; set; } = string.Empty;
    public string ProductFamily { get; set; } = string.Empty;
    public string ProductType { get; set; } = string.Empty;
    public string ProductNumber { get; set; } = string.Empty;
    public string Currency { get; set; } = string.Empty;
}

public class CatalogPdfTocItem {
    public string AnchorId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public int Level { get; set; }
}

public class CatalogPdfAssemblySection {
    public string AnchorId { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? PartNumber { get; set; }
    public string? Balloon { get; set; }
    public string ImageFilePath { get; set; } = string.Empty;
    public int Level { get; set; }
    public List<CatalogPdfPartRow> Parts { get; set; } = new();
}

public class CatalogPdfPartRow {
    public string Balloon { get; set; } = string.Empty;
    public string Quantity { get; set; } = string.Empty;
    public string PartNumber { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Weight { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
}
