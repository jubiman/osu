// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Graphics;
using osu.Game.Rulesets.Mania.Edit.Blueprints.Components;
using osu.Game.Rulesets.Mania.Objects;
using osuTK;

namespace osu.Game.Rulesets.Mania.Edit.Blueprints
{
    public class NotePlacementBlueprint : ManiaPlacementBlueprint<Note>
    {
        public NotePlacementBlueprint()
            : base(new Note())
        {
            Origin = Anchor.Centre;

            AutoSizeAxes = Axes.Y;

            InternalChild = new EditNotePiece { RelativeSizeAxes = Axes.X };
        }

        protected override void Update()
        {
            base.Update();

            Width = SnappedWidth;
            Position = SnappedMousePosition;
        }

        public override void UpdatePosition(Vector2 screenSpacePosition)
        {
            base.UpdatePosition(screenSpacePosition);

            // Continue updating the position until placement is finished on mouse up.
            BeginPlacement(TimeAt(screenSpacePosition), true);
        }
    }
}
