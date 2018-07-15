﻿using System;
using System.Globalization;

namespace FlatFiles.TypeMapping
{
    /// <summary>
    /// Represents the mapping from a type property to an unsigned short column.
    /// </summary>
    public interface IUInt16PropertyMapping
    {
        /// <summary>
        /// Sets the name of the column in the input or output file.
        /// </summary>
        /// <param name="name">The name of the column.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IUInt16PropertyMapping ColumnName(string name);

        /// <summary>
        /// Sets the format provider to use.
        /// </summary>
        /// <param name="provider">The provider to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IUInt16PropertyMapping FormatProvider(IFormatProvider provider);

        /// <summary>
        /// Sets the number styles to expect when parsing the input.
        /// </summary>
        /// <param name="styles">The number styles used in the input.</param>
        /// <returns>The property mappig for further configuration.</returns>
        IUInt16PropertyMapping NumberStyles(NumberStyles styles);

        /// <summary>
        /// Sets the output format to use.
        /// </summary>
        /// <param name="format">The format to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IUInt16PropertyMapping OutputFormat(string format);

        /// <summary>
        /// Sets what value(s) are treated as null.
        /// </summary>
        /// <param name="formatter">The formatter to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        /// <remarks>Passing null will cause the default formatter to be used.</remarks>
        IUInt16PropertyMapping NullFormatter(INullFormatter formatter);

        /// <summary>
        /// Sets the default value to use when a null is encountered on a non-null property.
        /// </summary>
        /// <param name="defaultValue">The default value to use.</param>
        /// <returns>The property mapping for further configuration.</returns>
        /// <remarks>Passing null will cause an exception to be thrown for unexpected nulls.</remarks>
        IUInt16PropertyMapping DefaultValue(IDefaultValue defaultValue);

        /// <summary>
        /// Sets a function to preprocess in the input before parsing it.
        /// </summary>
        /// <param name="preprocessor">A preprocessor function.</param>
        /// <returns>The property mapping for further configuration.</returns>
        IUInt16PropertyMapping Preprocessor(Func<string, string> preprocessor);
    }

    internal sealed class UInt16PropertyMapping : IUInt16PropertyMapping, IMemberMapping
    {
        private readonly UInt16Column column;

        public UInt16PropertyMapping(UInt16Column column, IMemberAccessor member, int physicalIndex, int logicalIndex)
        {
            this.column = column;
            Member = member;
            PhysicalIndex = physicalIndex;
            LogicalIndex = logicalIndex;
        }

        public IUInt16PropertyMapping ColumnName(string name)
        {
            column.ColumnName = name;
            return this;
        }

        public IUInt16PropertyMapping FormatProvider(IFormatProvider provider)
        {
            column.FormatProvider = provider;
            return this;
        }

        public IUInt16PropertyMapping NumberStyles(NumberStyles styles)
        {
            column.NumberStyles = styles;
            return this;
        }

        public IUInt16PropertyMapping OutputFormat(string format)
        {
            column.OutputFormat = format;
            return this;
        }

        public IUInt16PropertyMapping NullFormatter(INullFormatter formatter)
        {
            column.NullFormatter = formatter;
            return this;
        }

        public IUInt16PropertyMapping DefaultValue(IDefaultValue defaultValue)
        {
            column.DefaultValue = defaultValue;
            return this;
        }

        public IUInt16PropertyMapping Preprocessor(Func<string, string> preprocessor)
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
