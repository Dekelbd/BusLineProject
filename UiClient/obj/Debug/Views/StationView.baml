   M S B A M L   `   `   `  ����C  ?UiClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:UiClient.ViewsUiClient.Views  5      @ <Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullB-clr-namespace:Model.Interfaces;assembly=ModelModel.Interfaces 5      9!clr-namespace:UiClient.ConvertersUiClient.Converters  5      9!clr-namespace:UiClient.ViewModelsUiClient.ViewModels  5	           UiClient.Views.StationView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:UiClient.Views     5      D
interfaces-clr-namespace:Model.Interfaces;assembly=Model     5      8
converters!clr-namespace:UiClient.Converters     5      8
viewmodels!clr-namespace:UiClient.ViewModels     5	      LControls9http://schemas.microsoft.com/netfx/2009/xaml/presentation    6C     � 	Resources  5      &   System.Windows.Controls.DataGrid   StationDataGrid   Columns0  *System.Windows.Controls.DataGridTextColumn,  &System.Windows.Controls.DataGridColumn   Header   
IsReadOnly1  +System.Windows.Controls.DataGridBoundColumn   Binding �� Path��%,  &	          5   
   ��64   �� *
Stations+ 5        5      $ Station Name��6.    .  6D   �� $
 Name�6b     5      $ Latitude��6.    .  6@   �� $ Latitude�6b     5      $ 	Longitude��6.    .  6A   �� $ 	Longitude�6d   5      5      .��5      � 
�������.+�5   
        AutoGenerateColumns .  ��6   �� *
Stations+  5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property	 �� Value��%�   '        �� 5      "  6   .�5      ��  � ��
	 ��ح�63   �� 5       � ��$	 SemiBold"�63   �� 5       � ��$	 0,0,2,1q�68   �� 5       � ��
	 �   �64   5      5        5!        5"      $  Station Name��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 5#   0    6   �� *Name+60     5$      $ 
 Longitude��6%   $
 * 5%   5    6   �� *	Longitude+65     5&      $ 	 Latitude��6%   $
 * 5'   4    6   �� *
Latitude+64   5)      5*      5+      