namespace TaskNote.Platform
{
    /// <summary>
    /// 検索履歴のViewModel
    /// </summary>
    public class HistoryItemViewModel : BindableBase
    {

        private string _filterRuleText;

        public string FilterRuleText
        {
            get => _filterRuleText;
            set
            {
                _filterRuleText = value;
                RaisePropertyChanged();
            }
        }
    }
}
