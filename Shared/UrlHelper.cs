using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

public static class UrlHelper
{
    public static string Slugify(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        // Bỏ dấu
        var normalized = input.Normalize(NormalizationForm.FormD);
        var sb = new StringBuilder();
        foreach (var c in normalized)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                sb.Append(c);
            }
        }
        var noDiacritics = sb.ToString().Normalize(NormalizationForm.FormC);

        // Thay thế ký tự đặc biệt thành gạch ngang
        noDiacritics = noDiacritics.ToLowerInvariant();
        noDiacritics = noDiacritics.Replace("đ", "d");
        noDiacritics = Regex.Replace(noDiacritics, @"[^a-z0-9\s-]", "");
        noDiacritics = Regex.Replace(noDiacritics, @"\s+", "-");
        noDiacritics = noDiacritics.Trim('-');

        return noDiacritics;
    }

    public static string GenerateProductDetailUrl(
         int productId,
         string productName,
         int? categoryId,
         int? branchId,
         string? colorName)
    {
        var slug = Slugify(productName);

        string path;
        if (categoryId.HasValue)
        {
            path = $"/product-detail/{productId}/category={categoryId}/{slug}";
        }
        else
        {
            path = $"/product-detail/{productId}/{slug}";
        }

        var queryParams = new List<string>();

        if (branchId.HasValue)
            queryParams.Add($"branchId={branchId.Value}");

        if (!string.IsNullOrWhiteSpace(colorName))
            queryParams.Add($"color={Uri.EscapeDataString(colorName)}");

        if (queryParams.Any())
            path += "?" + string.Join("&", queryParams);

        return path;
    }


}
