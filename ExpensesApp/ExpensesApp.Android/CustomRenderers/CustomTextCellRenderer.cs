using Android.Content;
using Android.Views;
using ExpensesApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(TextCell), typeof(CustomTextCellRenderer))]
namespace ExpensesApp.Droid.CustomRenderers
{
    public class CustomTextCellRenderer : TextCellRenderer
	{
        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            var cell = base.GetCellCore(item, convertView, parent, context);

            switch (item.StyleId)
            {
                case "none":
                    cell.SetBackgroundColor(Color.AliceBlue.ToAndroid());
                    break;
                case "checkmark":
                    cell.SetBackgroundColor(Color.Aqua.ToAndroid());
                    break;
                case "detail-button":
                    cell.SetBackgroundColor(Color.Azure.ToAndroid());
                    break;
                case "detail-disclosure-button":
                    cell.SetBackgroundColor(Color.Bisque.ToAndroid());
                    break;
                case "disclosure":
                default:
                    cell.SetBackgroundColor(Color.BlanchedAlmond.ToAndroid());
                    break;
            }

            return cell;
        }
    }
}

