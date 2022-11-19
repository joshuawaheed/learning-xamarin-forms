using ExpensesApp.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("LPA")]
[assembly: ExportEffect(typeof(SelectedEffect), nameof(SelectedEffect))]
namespace ExpensesApp.Droid.Effects
{
    public class SelectedEffect : PlatformEffect
	{
		public SelectedEffect()
		{
		}

        protected override void OnAttached()
        {
            
        }

        protected override void OnDetached()
        {
            
        }
    }
}

