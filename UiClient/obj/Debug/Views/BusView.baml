   M S B A M L   `   `   `  ����C  ?UiClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:UiClient.ViewsUiClient.Views  5      @ <Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullB-clr-namespace:Model.Interfaces;assembly=ModelModel.Interfaces 5      9!clr-namespace:UiClient.ConvertersUiClient.Converters  5      ?$clr-namespace:UiClient.DataTemplatesUiClient.DataTemplates  5	      9!clr-namespace:UiClient.ViewModelsUiClient.ViewModels  5
          UiClient.Views.BusView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:UiClient.Views     5      D
interfaces-clr-namespace:Model.Interfaces;assembly=Model     5      8
converters!clr-namespace:UiClient.Converters     5      =DataTemplate$clr-namespace:UiClient.DataTemplates     5	      8
viewmodels!clr-namespace:UiClient.ViewModels     5
        � 	Resources  5      7   1UiClient.Converters.BusInfoToStringMultiConverter !  BusInfoToStringMultiConverter1   +UiClient.Converters.BusBorderColorConverter  BusBorderColorConverter  BusListBoxItemTemplate �� DataType  Model.Interfaces.Bus �� 	Converter `� 	Converter �� Path  BusListBoxItemTemplateTwo0  *UiClient.DataTemplates.BusTemplateSelector   BusListBoxItemTemplate    BusListBoxItemTemplateTwo  BusTemplateSelector��%i  &	        &	      &	 &     7  7   &	     7   &	     7  7    5   
   63     5   
   6-   �� 5   
   "  66   .R�5      �� .+�5      �� $��1q�6   ��6-   �� *Color+8   ._�5      �� $��2q�6   $	��120��6'   $��1��66   $��1��6C   $��15(�6S   ��5      `� 5      8  .1�5      �� $ Id�6&   �� 5      $ Driver.FirstName�6&   �� 5      $ Driver.LastName�6&   �� 5      $
 Type�6&   �� 5      $ 	Occupancy�6&   �� 5      $ Color�6&   �� 5      $ Lines�6&   5      5       5!      5"      5#      �� 5$   
   "  69   .R�5%      �� .+�5&      �� $��5q�6   
���   �._�5'      �� $��2q�6    $	��120��6+   $��1��6:   $��1��6G   $��15(�6W   ��5(      `� 5)      8   .1�5*   "   �� $ Id�6*   �� 5+   "   $ Driver.FirstName�6*   �� 5,   "   $ Driver.LastName�6*   �� 5-   "   $
 Type�6*   �� 5.   "   $ 	Occupancy�6*   �� 5/   "   $ Color�6*   �� 50   "   $ Lines�6*   51      53      54      55      56        58   
   8   8  5;      5<      .��5=      � 
������� � RowDefinitions 5>   
   �� 5?      $
��auto �6   �� 5@      $
��auto �6   �� 5A      $��* �6    � ColumnDefinitions 5C   
   �� 5D      $
��Auto �6   �� 5E      $
��Auto �6   �� 5F      $��* �6   .+�5H   
   �� $��0��6   $��0��6"   	 �� Orientation$	 
Horizontal=�62   .+�5I      �� $��0,20,0,3q�6   $��18(�6+   $��Bus ID:��69   �� 5J      -   5        
 ��Name$
 FilterTextbox��5J      $	��101��5K      $��25��6   $��5,20,0,3q�6+   $��17(�6=   ���	#FFF8FFFF��5J   -   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�5K   K   5L      �� 5M   
   -   5         ��Name$ BusList��5M   D   $��1��6   $��0��6    $��2��60   $
��Left=�6U   $	��Top=�6p   $	��500��5O      $	��300��6   ��5N      �� *FilterBuses+��67   ��  �� Source# [ 5O      5Q      5R      