using System;
using System.Collections.Generic;
using Unicorn.CoreTypes;

namespace Unicorn.Shapes
{
    /// <summary>
    /// A drawable that draws a horizontal arrow, with respect to the current context orientation.
    /// </summary>
    public class HorizontalArrow : IDrawable, IKnownSizeDrawable
    {
        /// <summary>
        /// Total length of the arrow from base to tip.
        /// </summary>
        public double Length { get; private set; }

        /// <summary>
        /// Thickness (breadth) of the arrow's stem or shaft.
        /// </summary>
        public double StemThickness { get; private set; }

        /// <summary>
        /// Breadth of the arrow's head.
        /// </summary>
        public double HeadBreadth { get; private set; }

        /// <summary>
        /// Length of the arrow's head, from the tip to the widest point.  An arrowhead with negative <see cref="HeadRake" /> will actually be longer.
        /// </summary>
        public double HeadLength { get; private set; }

        /// <summary>
        /// Determines the angle of the rear edges of the arrowhead.  If the arrow has a zero-width stem, these edges meet at a point on the centreline; the rake is the 
        /// difference between the X-coordinate of this point and the X-coordinate of the widest points of the arrowhead.  If negative, the arrowhead will be diamond- or kite-shaped.
        /// </summary>
        public double HeadRake { get; private set; }

        /// <summary>
        /// The direction the arrow points in.
        /// </summary>
        public HorizontalDirection Direction { get; private set; }

        /// <summary>
        /// The total width of the drawable - for a horizontal arrow this is equal to its <see cref="Length" />.
        /// </summary>
        public double Width => Length;

        /// <summary>
        /// The total height of the drawable - for a horizontal arrow this is equal to its <see cref="Height" />.
        /// </summary>
        public double Height => HeadBreadth;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="direction">The direction in which the arrow points.</param>
        /// <param name="length">Total length of the arrow.</param>
        /// <param name="stemThickness">Thickness of the arrow's stem.</param>
        /// <param name="headBreadth">Maximum breadth of the arrow's head.</param>
        /// <param name="headLength">Length of the arrow's head, from tip to its widest part.</param>
        /// <param name="headRake">Distance from the widest part of the arrowhead to the (potentially hypothetical) point where the rear edges of the arrowhead 
        ///   meet the centreline of the arrow.</param>
        public HorizontalArrow(HorizontalDirection direction, double length, double stemThickness, double headBreadth, double headLength, double headRake)
        {
            Direction = direction;
            Length = length;
            StemThickness = stemThickness;
            HeadBreadth = headBreadth;
            HeadLength = headLength;
            HeadRake = headRake;
        }

        /// <summary>
        /// Return a new arrow that is the same in all dimensions as this arrow, but points in the opposite direction.
        /// </summary>
        /// <returns></returns>
        public HorizontalArrow Flip()
        {
            HorizontalDirection dir = Direction == HorizontalDirection.ToLeft ? HorizontalDirection.ToRight : HorizontalDirection.ToLeft;
            return new HorizontalArrow(dir, Length, StemThickness, HeadBreadth, HeadLength, HeadRake);
        }

        /// <summary>
        /// Draw the arrow onto a context.
        /// </summary>
        /// <param name="context">The context to draw on.</param>
        /// <param name="x">The X coordinate of the upper-left corner of the arrow's bounding box.</param>
        /// <param name="y">The Y coordinate of the upper-left corner of the arrow's bounding box.</param>
        public void DrawAt(IGraphicsContext context, double x, double y)
        {
            double xBase = x;
            int factor = 1;
            if (context is null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (Direction == HorizontalDirection.ToLeft)
            {
                xBase += Width;
                factor = -1;
            }
            double effectiveStemThickness = StemThickness > HeadBreadth ? HeadBreadth : StemThickness;
            double effectiveHeadLength = HeadLength > Length ? Length : HeadLength;
            double effectiveHeadRake;
            if (HeadRake > effectiveHeadLength)
            {
                effectiveHeadRake = effectiveHeadLength;
            }
            else if (HeadRake < -(Length - effectiveHeadLength))
            {
                effectiveHeadRake = -(Length - effectiveHeadLength);
            }
            else
            {
                effectiveHeadRake = HeadRake;
            }
            double proportionalHeadRake = (HeadBreadth != 0) ? effectiveHeadRake * (HeadBreadth - effectiveStemThickness) / HeadBreadth : 0;
            double midY = HeadBreadth / 2;
            
            double stemY = effectiveStemThickness / 2;
            List<UniPoint> coords = new List<UniPoint>(9)
            {
                new UniPoint { X = xBase, Y = y + midY - stemY },
                new UniPoint { X = xBase, Y = y + midY + stemY },
                new UniPoint { X = xBase + factor * (Width + proportionalHeadRake - effectiveHeadLength), Y = y + midY + stemY },
                new UniPoint { X = xBase + factor * (Width - effectiveHeadLength), Y = y + Height },
                new UniPoint { X = xBase + factor * Width, Y = y + midY },
                new UniPoint { X = xBase + factor * (Width - effectiveHeadLength), Y = y },
                new UniPoint { X = xBase + factor * (Width + proportionalHeadRake - effectiveHeadLength), Y = y + midY - stemY },
                new UniPoint { X = xBase, Y = y + midY - stemY }
            };
            context.DrawFilledPolygon(coords);
        }
    }
}
