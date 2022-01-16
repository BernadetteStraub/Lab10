using Xamarin.Forms;

namespace Straub_Bernadette_Lab10
{
    public class ValidationBehaviour: Behavior<Editor>
    {
        protected override void OnAttachedTo(Editor entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Editor entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }
        
        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            ((Editor)sender).BackgroundColor =
                string.IsNullOrEmpty(args.NewTextValue)?  Color.Red : Color.Default;
        }
    }
}