using System;
using System.Linq;

namespace OpenAgenticLabs.LLMZeroPrompt.Core.UtilitiesN;

/// <summary>
/// A static class for comparing version strings in the format "1.0.0".
/// </summary>
/// <example>
/// bool isEqual = VersionComparer.IsEqual("1.0.0", "1.0.0"); // true
/// bool isLess = VersionComparer.IsLessThan("1.0.0", "1.1.0"); // true
/// bool isGreater = VersionComparer.IsGreaterThan("2.0.0", "1.5.0"); // true
/// bool isLessOrEqual = VersionComparer.IsLessThanOrEqual("1.0.0", "1.0.0"); // true
/// bool isGreaterOrEqual = VersionComparer.IsGreaterThanOrEqual("2.0.0", "2.0.0"); // true
/// </example>
public static class VersionComparer
{
    /// <summary>
    /// Checks if two version strings are equal.
    /// </summary>
    /// <param name="version1">The first version string.</param>
    /// <param name="version2">The second version string.</param>
    /// <returns>True if the versions are equal, false otherwise.</returns>
    public static bool IsEqual(string version1, string version2)
    {
        try
        {
            return CompareVersions(version1, version2) == 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Checks if the first version is less than the second version.
    /// </summary>
    /// <param name="version1">The first version string.</param>
    /// <param name="version2">The second version string.</param>
    /// <returns>True if the first version is less than the second, false otherwise.</returns>
    public static bool IsLessThan(string version1, string version2)
    {
        try
        {
            return CompareVersions(version1, version2) < 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Checks if the first version is greater than the second version.
    /// </summary>
    /// <param name="version1">The first version string.</param>
    /// <param name="version2">The second version string.</param>
    /// <returns>True if the first version is greater than the second, false otherwise.</returns>
    public static bool IsGreaterThan(string version1, string version2)
    {
        try
        {
            return CompareVersions(version1, version2) > 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Checks if the first version is less than or equal to the second version.
    /// </summary>
    /// <param name="version1">The first version string.</param>
    /// <param name="version2">The second version string.</param>
    /// <returns>True if the first version is less than or equal to the second, false otherwise.</returns>
    public static bool IsLessThanOrEqual(string version1, string version2)
    {
        try
        {
            return CompareVersions(version1, version2) <= 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Checks if the first version is greater than or equal to the second version.
    /// </summary>
    /// <param name="version1">The first version string.</param>
    /// <param name="version2">The second version string.</param>
    /// <returns>True if the first version is greater than or equal to the second, false otherwise.</returns>
    public static bool IsGreaterThanOrEqual(string version1, string version2)
    {
        try
        {
            return CompareVersions(version1, version2) >= 0;
        }
        catch (Exception)
        {
            throw;
        }
    }

    private static int CompareVersions(string version1, string version2)
    {
        if (string.IsNullOrWhiteSpace(version1))
            throw new ArgumentNullException(nameof(version1), "Version string cannot be null or empty");
        if (string.IsNullOrWhiteSpace(version2))
            throw new ArgumentNullException(nameof(version2), "Version string cannot be null or empty");

        int[] v1 = ParseVersion(version1);
        int[] v2 = ParseVersion(version2);

        for (int i = 0; i < Math.Max(v1.Length, v2.Length); i++)
        {
            int compareResult = v1.ElementAtOrDefault(i).CompareTo(v2.ElementAtOrDefault(i));
            if (compareResult != 0)
                return compareResult;
        }

        return 0;
    }

    private static int[] ParseVersion(string version)
    {
        if (!IsValidVersionFormat(version))
            throw new ArgumentException("Invalid version format. Expected format: 1.0.0", nameof(version));

        return version.Split('.').Select(int.Parse).ToArray();
    }

    private static bool IsValidVersionFormat(string version)
    {
        string[] parts = version.Split('.');
        return parts.Length == 3 && parts.All(part => int.TryParse(part, out _));
    }
}
