using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Linq;

namespace Olib.Core
{
    internal class Animations
    {
        /// <summary>
        /// Активирует анимацию для текста
        /// </summary>
        /// <param name="control">Элемент, для которого нужно активировать анимацию, в данном случае DropShadow</param>
        public static void AnimationText(DropShadowEffect control)
        {
            DoubleAnimation anim = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                To = 10,
                RepeatBehavior = RepeatBehavior.Forever,
                AutoReverse = true
            };
            Timeline.SetDesiredFrameRate(anim, 60);
            control.BeginAnimation(DropShadowEffect.BlurRadiusProperty, anim);
        }
        /// <summary>
        /// Активирует анимацию для текста
        /// </summary>
        /// <param name="control">Элемент, для которого нужно активировать анимацию</param>
        /// <param name="control1">Второй элемент, для которого нужно активировать анимацию/param>
        public static void AnimationText(DropShadowEffect control, DropShadowEffect control1)
        {
            DoubleAnimation anim = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(1),
                To = 10,
                RepeatBehavior = RepeatBehavior.Forever,
                AutoReverse = true
            };
            Timeline.SetDesiredFrameRate(anim, 60);
            control.BeginAnimation(DropShadowEffect.BlurRadiusProperty, anim);
            control1.BeginAnimation(DropShadowEffect.BlurRadiusProperty, anim);
        }
    }
}
