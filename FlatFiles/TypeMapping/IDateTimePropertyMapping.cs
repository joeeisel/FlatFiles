﻿using System;

namespace FlatFiles.TypeMapping
{
    /// <summary>
    /// Represents the mapping from a type property to a DateTime column.
    /// </summary>
    public interface IDateTimePropertyMapping
    {
        /// <summary>
        /// Sets the name of the column in the input or output file.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IDateTimePropertyMapping ColumnName(string name);

        /// <summary>
        /// Sets the date/time format the input is expected to be in.
        /// </summary>
        /// <param name="format">The format to expect.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IDateTimePropertyMapping InputFormat(string? format);

        /// <summary>
        /// Sets the date/time format to use for output.
        /// </summary>
        /// <param name="format">The format to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IDateTimePropertyMapping OutputFormat(string? format);

        /// <summary>
        /// Sets the format provider to use when reading and writing date/times.
        /// </summary>
        /// <param name="provider">The provider to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IDateTimePropertyMapping FormatProvider(IFormatProvider? provider);

        /// <summary>
        /// Sets what value(s) are treated as null.
        /// </summary>
        /// <param name="formatter">The formatter to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        /// <remarks>Passing null will cause the default formatter to be used.</remarks>
        IDateTimePropertyMapping NullFormatter(INullFormatter formatter);

        /// <summary>
        /// Sets the default value to use when a null is encountered on a non-null property.
        /// </summary>
        /// <param name="defaultValue">The default value to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        /// <remarks>Passing null will cause an exception to be thrown for unexpected nulls.</remarks>
        IDateTimePropertyMapping DefaultValue(IDefaultValue defaultValue);

        /// <summary>
        /// Sets a function to preprocess in the input before parsing it.
        /// </summary>
        /// <param name="preprocessor">A preprocessor function.</param>
        /// <returns>The property mapping for further configuration.</returns>
        [Obsolete("This function has been superseded by the OnParsing function.")]
        IDateTimePropertyMapping Preprocessor(Func<string, string?>? preprocessor);

        /// <summary>
        /// Sets the function to run before the input is parsed.
        /// </summary>
        /// <param name="handler">A function to call before the textual value is parsed.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IDateTimePropertyMapping OnParsing(Func<IColumnContext?, string, string?>? handler);

        /// <summary>
        /// Sets the function to run after the input is parsed.
        /// </summary>
        /// <param name="handler">A function to call after the value is parsed.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IDateTimePropertyMapping OnParsed(Func<IColumnContext?, object?, object?>? handler);

        /// <summary>
        /// Sets the function to run before the output is formatted as a string.
        /// </summary>1
        /// <param name="handler">A function to call before the value is formatted as a string.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IDateTimePropertyMapping OnFormatting(Func<IColumnContext?, object?, object?>? handler);

        /// <summary>
        /// Sets the function to run after the output is formatted as a string.
        /// </summary>
        /// <param name="handler">A function to call after the value is formatted as a string.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IDateTimePropertyMapping OnFormatted(Func<IColumnContext?, string, string?>? handler);
    }
}
