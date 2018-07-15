﻿using System;
using System.Globalization;

namespace FlatFiles.TypeMapping
{
    /// <summary>
    /// Represents the mapping from a type property to a int column.
    /// </summary>
    public interface IInt32PropertyMapping
    {
        /// <summary>
        /// Sets the name of the column in the input or output file.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IInt32PropertyMapping ColumnName(string name);

        /// <summary>
        /// Sets the format provider to use.
        /// </summary>
        /// <param name="provider">The provider to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IInt32PropertyMapping FormatProvider(IFormatProvider provider);

        /// <summary>
        /// Sets the number styles to expect when parsing the input.
        /// </summary>
        /// <param name="styles">The number styles used in the input.</param>
        /// <returns>The property mappig for further configuration.</returns>
        IInt32PropertyMapping NumberStyles(NumberStyles styles);

        /// <summary>
        /// Sets the output format to use.
        /// </summary>
        /// <param name="format">The format to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IInt32PropertyMapping OutputFormat(string format);

        /// <summary>
        /// Sets what value(s) are treated as null.
        /// </summary>
        /// <param name="formatter">The formatter to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        /// <remarks>Passing null will cause the default formatter to be used.</remarks>
        IInt32PropertyMapping NullFormatter(INullFormatter formatter);

        /// <summary>
        /// Sets the default value to use when a null is encountered on a non-null property.
        /// </summary>
        /// <param name="defaultValue">The default value to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        /// <remarks>Passing null will cause an exception to be thrown for unexpected nulls.</remarks>
        IInt32PropertyMapping DefaultValue(IDefaultValue defaultValue);

        /// <summary>
        /// Sets a function to preprocess in the input before parsing it.
        /// </summary>
        /// <param name="preprocessor">A preprocessor function.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IInt32PropertyMapping Preprocessor(Func<string, string> preprocessor);
    }

    internal sealed class Int32PropertyMapping : IInt32PropertyMapping, IMemberMapping
    {
        private readonly Int32Column column;

        public Int32PropertyMapping(Int32Column column, IMemberAccessor member, int physicalIndex, int logicalIndex)
        {
            this.column = column;
            Member = member;
            PhysicalIndex = physicalIndex;
            LogicalIndex = logicalIndex;
        }

        public IInt32PropertyMapping ColumnName(string name)
        {
            column.ColumnName = name;
            return this;
        }

        public IInt32PropertyMapping FormatProvider(IFormatProvider provider)
        {
            column.FormatProvider = provider;
            return this;
        }

        public IInt32PropertyMapping NumberStyles(NumberStyles styles)
        {
            column.NumberStyles = styles;
            return this;
        }

        public IInt32PropertyMapping OutputFormat(string format)
        {
            column.OutputFormat = format;
            return this;
        }

        public IInt32PropertyMapping NullFormatter(INullFormatter formatter)
        {
            column.NullFormatter = formatter;
            return this;
        }

        public IInt32PropertyMapping DefaultValue(IDefaultValue defaultValue)
        {
            column.DefaultValue = defaultValue;
            return this;
        }

        public IInt32PropertyMapping Preprocessor(Func<string, string> preprocessor)
        {
            column.Preprocessor = preprocessor;
            return this;
        }

        public IMemberAccessor Member { get; }

        public Action<IColumnContext, object, object> Reader => null;

        public Action<IColumnContext, object, object[]> Writer => null;

        public IColumnDefinition ColumnDefinition => column;

        public int PhysicalIndex { get; }

        public int LogicalIndex { get; }
    }
}
