using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using ITD.Minitor.ViewModel.Object;

namespace ITD.Minitor.ViewModel.ViewTemplate
{
    public class ViewTemplateColunm
    {
        static Style styleBorder = Application.Current.FindResource("borderCell") as Style;
        static Style styleTextBlock = Application.Current.FindResource("txtField") as Style;
        static Style styleTextBlockHeader = Application.Current.FindResource("txtColumnHeader") as Style;
        static Style styleImage = Application.Current.FindResource("imgAlarm") as Style;

        public static DataTemplate getDataTemplate(int count)
        {
            DataTemplate template = new DataTemplate();

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.StyleProperty, styleBorder);
            FrameworkElementFactory gridFactory = new FrameworkElementFactory(typeof(Grid));
            FrameworkElementFactory columnDefinitionFactory = new FrameworkElementFactory(typeof(ColumnDefinition));
            columnDefinitionFactory.SetValue(ColumnDefinition.WidthProperty, new GridLength(1.5, GridUnitType.Star));
            FrameworkElementFactory columnDefinitionFactory1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            columnDefinitionFactory.SetValue(ColumnDefinition.WidthProperty, new GridLength(3, GridUnitType.Star));

            gridFactory.AppendChild(columnDefinitionFactory1);
            gridFactory.AppendChild(columnDefinitionFactory);

            FrameworkElementFactory imgFactory = new FrameworkElementFactory(typeof(Image));
            imgFactory.SetValue(Image.ToolTipProperty, new Binding(string.Format("MucDoThietBi[{0}]", count)));
            imgFactory.SetValue(Image.StyleProperty, styleImage);
            imgFactory.SetValue(Grid.ColumnProperty, 0);

            FrameworkElementFactory textblockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textblockFactory.SetValue(TextBlock.StyleProperty, styleTextBlock);
            textblockFactory.SetBinding(TextBlock.ToolTipProperty, new Binding(string.Format("MucDoThietBi[{0}]", count)));
            textblockFactory.SetBinding(TextBlock.TextProperty, new Binding(string.Format("ThietBi[{0}]", count)));
            textblockFactory.SetValue(Grid.ColumnProperty, 1);

            template.VisualTree = borderFactory;
            borderFactory.AppendChild(gridFactory);
            gridFactory.AppendChild(imgFactory);
            gridFactory.AppendChild(textblockFactory);
            return template;
        }

        public static DataTemplate getDataTemplate_FistColumn(string xName)
        {
            DataTemplate template = new DataTemplate();

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            borderFactory.SetValue(Border.StyleProperty, styleBorder);
            FrameworkElementFactory gridFactory = new FrameworkElementFactory(typeof(Grid));

            gridFactory.SetValue(Grid.WidthProperty, 130D);
            //gridFactory.SetValue(Grid.ColumnDefinition)
            FrameworkElementFactory columnDefinitionFactory = new FrameworkElementFactory(typeof(ColumnDefinition));
            columnDefinitionFactory.SetValue(ColumnDefinition.WidthProperty, new GridLength(1.5, GridUnitType.Star));
            FrameworkElementFactory columnDefinitionFactory1 = new FrameworkElementFactory(typeof(ColumnDefinition));
            columnDefinitionFactory.SetValue(ColumnDefinition.WidthProperty, new GridLength(3, GridUnitType.Star));

            gridFactory.AppendChild(columnDefinitionFactory1);
            gridFactory.AppendChild(columnDefinitionFactory);


            FrameworkElementFactory textblockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textblockFactory.SetValue(TextBlock.StyleProperty, styleTextBlock);
            textblockFactory.SetBinding(TextBlock.TextProperty, new Binding(string.Format(xName)));
            textblockFactory.SetValue(Grid.ColumnProperty, 1);
            textblockFactory.SetValue(TextBlock.ToolTipProperty, new Binding(string.Format(xName)));

            template.VisualTree = borderFactory;
            borderFactory.AppendChild(gridFactory);
            gridFactory.AppendChild(textblockFactory);

            return template;
        }

        public static DataTemplate getDataTemplate_ColumnHeader(string xName)
        {
            DataTemplate template = new DataTemplate();

            FrameworkElementFactory borderFactory = new FrameworkElementFactory(typeof(Border));
            //borderFactory.SetValue(Border.VerticalAlignmentProperty, VerticalAlignment.Top);
            //borderFactory.SetValue(Border.HorizontalAlignmentProperty, HorizontalAlignment.Stretch);

            FrameworkElementFactory textblockFactory = new FrameworkElementFactory(typeof(TextBlock));
            textblockFactory.SetValue(TextBlock.TextProperty, xName);
            textblockFactory.SetValue(Border.VerticalAlignmentProperty, VerticalAlignment.Top);

            textblockFactory.SetValue(TextBlock.StyleProperty, styleTextBlockHeader);

            template.VisualTree = borderFactory;
            borderFactory.AppendChild(textblockFactory);


            return template;
        }

        public void StatisticView(List<Computer> oListView, Label lblall, Label lblon, Label lbloff)
        {
            int all = oListView.Count;
            int off = 0;
            for (int i = 0; i < oListView.Count; i++)
            {
                if (oListView[i].TrangThai == "TẮT")
                    off += 1;
            }
            lblall.Content = all.ToString();
            lblon.Content = (all - off).ToString();
            lbloff.Content = off.ToString();
        }
    }
}