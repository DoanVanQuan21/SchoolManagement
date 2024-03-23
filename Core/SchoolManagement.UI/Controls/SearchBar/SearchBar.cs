﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml.Templates;
using Avalonia.Styling;
using System.Windows.Input;

namespace SchoolManagement.UI.Controls.SearchBar
{
    public class SearchBar : TemplatedControl, IStyleable
    {
        private TextBox textBox;
        private Button clearButton;
        Type IStyleable.StyleKey => typeof(TemplatedControl);

        public string Text
        {
            get => GetValue(TextProperty); set => SetValue(TextProperty, value);
        }

        public ICommand SearchCommand
        {
            get => GetValue(SearchCommandProperty);
            set => SetValue(SearchCommandProperty, value);
        }

        public static StyledProperty<string> TextProperty = AvaloniaProperty.Register<SearchBar, string>(nameof(Text));
        public static StyledProperty<ICommand> SearchCommandProperty = AvaloniaProperty.Register<SearchBar, ICommand>(nameof(SearchCommand));

        static SearchBar()
        {
            TextProperty.Changed.AddClassHandler<SearchBar>((s, e) => s.OnTextChanged(e));
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            textBox = e.NameScope.Find<TextBox>("PART_TextBox");
            clearButton = e.NameScope.Find<Button>("PART_ClearButton");
            if (textBox != null)
            {
                textBox.KeyUp += TextBox_KeyUp;
                textBox.GetObservable(TextBox.TextProperty).Subscribe(text => { Text = text; });
                textBox.KeyDown += TextBox_KeyDown;
            }
            if (clearButton != null)
            {
                clearButton.Click += ClearButton_Click;
            }
        }
        private void ClearButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            Text = string.Empty;
            SearchCommand?.Execute(Text);
        }

        private void TextBox_KeyDown(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            if(e.Key != Avalonia.Input.Key.Enter)
            {
                return;
            }
            SearchCommand?.Execute(Text);
        }

        private void TextBox_KeyUp(object? sender, Avalonia.Input.KeyEventArgs e)
        {
            SearchCommand?.Execute(Text);
        }

        private void OnTextChanged(AvaloniaPropertyChangedEventArgs e)
        {
            if (textBox == null)
            {
                return;
            }
            textBox.Text = (string)e.NewValue;
        }

    }
}