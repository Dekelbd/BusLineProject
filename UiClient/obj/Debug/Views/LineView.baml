   M S B A M L   `   `   `  ����C  ?UiClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:UiClient.ViewsUiClient.Views  5      @ <Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullB-clr-namespace:Model.Interfaces;assembly=ModelModel.Interfaces 5      9!clr-namespace:UiClient.ConvertersUiClient.Converters  5      9!clr-namespace:UiClient.ViewModelsUiClient.ViewModels  5	          UiClient.Views.LineView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:UiClient.Views     5      D
interfaces-clr-namespace:Model.Interfaces;assembly=Model     5      8
converters!clr-namespace:UiClient.Converters     5      8
viewmodels!clr-namespace:UiClient.ViewModels     5	        � 	Resources  5      8   2UiClient.Converters.LineInfoToStringMultiConverter "  LineInfoToStringMultiConverter  LineListBoxItemTemplate �� DataType  Model.Interfaces.Line `� 	Converter �� Path��%4  &	        &	      7     5   
   64   �� 5   
   "  67   .R�5      �� .+�5      �� $��2q�6   $	��120��6'   $��1��66   $��1��6C   $��15(�6S   ��5      `� 5      8   .1�5      �� $ LineName�6&   �� 5      $ Stations�6&   5      5      5      5      5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5       $��* �6    � ColumnDefinitions 5"   
   �� 5#      $
��Auto �6   �� 5$      $
��Auto �6   �� 5%      $
��Auto �6   �� 5&      $��* �6   .+�5(   
   �� #��[ 60   $��4��6h   $	��273��6|   $��4��6�   $	��626��6�   $��	36,81,0,0q�6�   ��6   �� *Lines+6�   5)      5*      