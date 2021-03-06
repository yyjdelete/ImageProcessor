﻿// <copyright file="Glow.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageProcessorCore
{
    using Processors;

    /// <summary>
    /// Extension methods for the <see cref="Image{TColor, TPacked}"/> type.
    /// </summary>
    public static partial class ImageExtensions
    {
        /// <summary>
        /// Applies a radial glow effect to an image.
        /// </summary>
        /// <typeparam name="TColor">The pixel format.</typeparam>
        /// <typeparam name="TPacked">The packed format. <example>uint, long, float.</example></typeparam>
        /// <param name="source">The image this method extends.</param>
        /// <returns>The <see cref="Image{TColor, TPacked}"/>.</returns>
        public static Image<TColor, TPacked> Glow<TColor, TPacked>(this Image<TColor, TPacked> source)
            where TColor : IPackedVector<TPacked>
            where TPacked : struct
        {
            return Glow(source, default(TColor), source.Bounds.Width * .5F, source.Bounds);
        }

        /// <summary>
        /// Applies a radial glow effect to an image.
        /// </summary>
        /// <typeparam name="TColor">The pixel format.</typeparam>
        /// <typeparam name="TPacked">The packed format. <example>uint, long, float.</example></typeparam>
        /// <param name="source">The image this method extends.</param>
        /// <param name="color">The color to set as the glow.</param>
        /// <returns>The <see cref="Image{TColor, TPacked}"/>.</returns>
        public static Image<TColor, TPacked> Glow<TColor, TPacked>(this Image<TColor, TPacked> source, TColor color)
            where TColor : IPackedVector<TPacked>
            where TPacked : struct
        {
            return Glow(source, color, source.Bounds.Width * .5F, source.Bounds);
        }

        /// <summary>
        /// Applies a radial glow effect to an image.
        /// </summary>
        /// <typeparam name="TColor">The pixel format.</typeparam>
        /// <typeparam name="TPacked">The packed format. <example>uint, long, float.</example></typeparam>
        /// <param name="source">The image this method extends.</param>
        /// <param name="radius">The the radius.</param>
        /// <returns>The <see cref="Image{TColor, TPacked}"/>.</returns>
        public static Image<TColor, TPacked> Glow<TColor, TPacked>(this Image<TColor, TPacked> source, float radius)
            where TColor : IPackedVector<TPacked>
            where TPacked : struct
        {
            return Glow(source, default(TColor), radius, source.Bounds);
        }

        /// <summary>
        /// Applies a radial glow effect to an image.
        /// </summary>
        /// <typeparam name="TColor">The pixel format.</typeparam>
        /// <typeparam name="TPacked">The packed format. <example>uint, long, float.</example></typeparam>
        /// <param name="source">The image this method extends.</param>
        /// <param name="rectangle">
        /// The <see cref="Rectangle"/> structure that specifies the portion of the image object to alter.
        /// </param>
        /// <returns>The <see cref="Image{TColor, TPacked}"/>.</returns>
        public static Image<TColor, TPacked> Glow<TColor, TPacked>(this Image<TColor, TPacked> source, Rectangle rectangle)
            where TColor : IPackedVector<TPacked>
            where TPacked : struct
        {
            return Glow(source, default(TColor), 0, rectangle);
        }

        /// <summary>
        /// Applies a radial glow effect to an image.
        /// </summary>
        /// <typeparam name="TColor">The pixel format.</typeparam>
        /// <typeparam name="TPacked">The packed format. <example>uint, long, float.</example></typeparam>
        /// <param name="source">The image this method extends.</param>
        /// <param name="color">The color to set as the glow.</param>
        /// <param name="radius">The the radius.</param>
        /// <param name="rectangle">
        /// The <see cref="Rectangle"/> structure that specifies the portion of the image object to alter.
        /// </param>
        /// <returns>The <see cref="Image{TColor, TPacked}"/>.</returns>
        public static Image<TColor, TPacked> Glow<TColor, TPacked>(this Image<TColor, TPacked> source, TColor color, float radius, Rectangle rectangle)
            where TColor : IPackedVector<TPacked>
            where TPacked : struct
        {
            GlowProcessor<TColor, TPacked> processor = new GlowProcessor<TColor, TPacked> { Radius = radius, };

            if (!color.Equals(default(TColor)))
            {
                processor.GlowColor = color;
            }

            return source.Process(rectangle, processor);
        }
    }
}
