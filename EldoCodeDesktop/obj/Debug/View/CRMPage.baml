   M S B A M L   `   `   `  ����J  FEldoCodeDesktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:EldoCodeDesktop.ViewEldoCodeDesktop.View  5      A%clr-namespace:EldoCodeDesktop.AppDataEldoCodeDesktop.AppData  5      b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5	      "    EldoCodeDesktop.View.CRMPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:EldoCodeDesktop.View     5      R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5      2local1%clr-namespace:EldoCodeDesktop.AppData  5      XThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2  5	        N� Title$	  CRM��5       � 	Resources 5         ComboBox.Static.Background �� EndPoint �� 
StartPoint � Color � Offset  ComboBox.Static.Border �� Color ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background * &ComboBox.Static.Editable.Button.Border  ComboBox.MouseOver.Glyph ! ComboBox.MouseOver.Background  ComboBox.MouseOver.Border *	 &ComboBox.MouseOver.Editable.Background &
 "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Glyph  ComboBox.Pressed.Background  ComboBox.Pressed.Border ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border  ComboBox.Disabled.Glyph   ComboBox.Disabled.Background  ComboBox.Disabled.Border ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border  ComboBox.Static.Glyph  ComboBoxToggleButton �� 
TargetType �� Property	 �� Value
 �� 
TargetType ��Name J� SnapsToDevicePixels �� CornerRadius F�Name �� Triggers ^� 
Conditions �� Binding �� RelativeSource �� AncestorType �� Value �� 
TargetName P� Property P� Value  ComboBoxTemplate �Name � ColumnDefinitions �Name � AllowsTransparency �� Mode5  /Microsoft.Windows.Themes.SystemDropShadowChrome  Name   Color �� MaxDropDownHeight  �� ElementName! ��Name" �� ClearTypeHint# ��Name$ ��Name% ��Name-  'System.Windows.Input.KeyboardNavigation&   DirectionalNavigation' d�Name( d� 	IsChecked) ��Name* �� SelectionBoxItemTemplate+ �� SelectionBoxItem#, �� SelectionBoxItemStringFormat- �� ContentStringFormat. J� IsHitTestVisible/ P� 
SourceName0 ]� 
Conditions1 �� Property  TextBox.Static.Background  ComboBoxEditableTextBox   ComboBoxEditableTemplate2 ��Name3 �� 
IsReadOnly ! ComboBoxStyle1 " FocusVisual4 �� Triggers��%-  &	        &	 �     &	 �     &	 �     &	     &	 *    &	 O    &	 r    &	     &		 1    &	
 T    &	 w    &	     &	 6    &	 Y    &	 �    &	     &	 ;    &	 ^    &	 �    &	     &	 @    &	 c    &	 �    &	 �    &	 �    &	 �    &	     &	 9    7  7   7  7  7  7  7  7  7  7  7 	 7 
 7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  7  &	 d    7  &	 �    &	     &	  $    7  7  7  &	! �(    7 " 7   7  7  7   �� 5   
   $	 0,1&�6A   $	 0,0&�6P   .��5      � $ 	#FFF0F0F0��6   $	 0.0Q�6-   � 5      $ 	#FFE5E5E5��6   $	 1.0Q�6-   5      �� 5   
   $ 	#FFACACAC��69   �� 5   
   $ 	#FFFFFFFF��6F   �� 5   
   $ 	#FFABADB3��6B   �� 5   
   $ Transparent��6M   �� 5   
   $ Transparent��6I   �� 5   
   $ 	#FF000000��6;   �� 5   
   $	 0,1&�6D   $	 0,0&�6S   .��5      � $ 	#FFECF4FC��6   $	 0.0Q�6-   � 5      $ 	#FFDCECFC��6   $	 1.0Q�6-   5      �� 5   
   $ 	#FF7EB4EA��6<   �� 5   
   $ 	#FFFFFFFF��6I   �� 5   
   $ 	#FF7EB4EA��6E   �� 5    
   $	 0,1&�6T   $	 0,0&�6c   .��5!      � $ 	#FFEBF4FC��6   $	 0.0Q�6-   � 5"      $ 	#FFDCECFC��6   $	 1.0Q�6-   5#      �� 5$   
   $ 	#FF7EB4EA��6L   �� 5%   
   $ 	#FF000000��69   �� 5&   
   $	 0,1&�6B   $	 0,0&�6Q   .��5'      � $ 	#FFDAECFC��6   $	 0.0Q�6-   � 5(      $ 	#FFC4E0FC��6   $	 1.0Q�6-   5)      �� 5*   
   $ 	#FF569DE5��6:   �� 5+   
   $ 	#FFFFFFFF��6G   �� 5,   
   $ 	#FF569DE5��6C   �� 5-   
   $	 0,1&�6R   $	 0,0&�6a   .��5.      � $ 	#FFDAEBFC��6   $	 0.0Q�6-   � 5/      $ 	#FFC4E0FC��6   $	 1.0Q�6-   50      �� 51   
   $ 	#FF569DE5��6J   �� 52   
   $ 	#FFBFBFBF��6:   �� 53   
   $ 	#FFF0F0F0��6?   �� 54   
   $ 	#FFD9D9D9��6;   �� 55   
   $ 	#FFFFFFFF��6H   �� 56   
   $ 	#FFBFBFBF��6D   �� 57   
   $ Transparent��6O   �� 58   
   $ Transparent��6K   �� 59   
   $ 	#FF606060��68   �� 5:   
   " d�6-   .�5;      ��  �@�OverridesDefaultStyle	 . 66   �� 5<       � ��	 .  6*   �� 5=       � |�	 .  6*   �� 5>       �@��	ClickMode$	 Press=�6*   �� 5?       � ��	 5@      �� 5A      "
 d�6&   .R�5B      �� $ templateRoot��6!   8��  #��z��6m   8��  . $ 5��6�   ._�5C      �� $ splitBorder��6%   
������ $��1q�6T   $��Right=�6h   $��0q�6�    . #��� r�6�   ._�5D   "   F� $ arrow��6'   F����        ���( ��( јaQ     јaQ P����̰( � �    P����        8�� $��Center=�6�   $��0q�6�   $��Center=�6�   5E      5F       5G      ^� 5H       5I   "   �� 5J   &    60   �� *
IsEditable+ �� " �� true6�   �� 5K   &    60   �� *IsMouseOver+ �� *Self+	 false6v   �� 5L   &    60   �� *	IsPressed+ �� *Self+	 false6t   �� 5M   &    60   �� *	IsEnabled+ �� *Self+ true6t   .0�5O   "   �� $ templateRoot��6?   8	   � ��6Y   �� 5P   "   $ templateRoot��6@   8	   � ��6Z   �� 5Q   "   $ splitBorder��6?   8	   � ��6X   �� 5R   "   $ splitBorder��6@   8	   � ��6Y   5S      P� 5T       �@J�IsMouseOver . . �5U   "   �� $ arrow��69   8	   � ��6L   5V      ^� 5W       5X   "   �� 5Y   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5Z   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5\   "   �� $ templateRoot��6?   8	   � ��6Y   �� 5]   "   $ templateRoot��6@   8	 	  � ��6Z   5^      ^� 5_       5`   "   �� 5a   &    60   �� *IsMouseOver+ �� *Self+ true6v   �� 5b   &    60   �� *
IsEditable+ �� " �� true6�   .0�5d   "   �� $ templateRoot��6?   8	 
  � ��6Y   �� 5e   "   $ templateRoot��6@   8	   � ��6Z   �� 5f   "   $ splitBorder��6?   8	   � ��6X   �� 5g   "   $ splitBorder��6@   8	   � ��6Y   5h      P� 5i       � �� . . �5j   "   �� $ arrow��69   8	   � ��6L   5k      ^� 5l       5m   "   �� 5n   &    60   �� *	IsPressed+ �� *Self+ true6t   �� 5o   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5q   "   �� $ templateRoot��6?   8	   � ��6Y   �� 5r   "   $ templateRoot��6@   8	   � ��6Z   5s      ^� 5t       5u   "   �� 5v   &    60   �� *	IsPressed+ �� *Self+ true6t   �� 5w   &    60   �� *
IsEditable+ �� " �� true6�   .0�5y   "   �� $ templateRoot��6?   8	   � ��6Y   �� 5z   "   $ templateRoot��6@   8	   � ��6Z   �� 5{   "   $ splitBorder��6?   8	   � ��6X   �� 5|   "   $ splitBorder��6@   8	   � ��6Y   5}      P� 5~       � {� .  . �5   "   �� $ arrow��69   8	   � ��6L   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5�   &    60   �� *
IsEditable+ �� " ��	 false6�   .0�5�   "   �� $ templateRoot��6?   8	   � ��6Y   �� 5�   "   $ templateRoot��6@   8	   � ��6Z   5�      ^� 5�       5�   "   �� 5�   &    60   �� *	IsEnabled+ �� *Self+	 false6t   �� 5�   &    60   �� *
IsEditable+ �� " �� true6�   .0�5�   "   �� $ templateRoot��6?   8	   � ��6Y   �� 5�   "   $ templateRoot��6@   8	   � ��6Z   �� 5�   "   $ splitBorder��6?   8	   � ��6X   �� 5�   "   $ splitBorder��6@   8	   � ��6Y   5�      5�      5�      5�      �� 5�   
   "
 ��63   .R�5�      � $ templateRoot��6    .  5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6    . $��2��6F   $��1q�6�   #��� .�6�   $��Bottom=�6  ��6Z   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5�        $ shadow��64   $ Transparent��6D   #��z 6X   ��6�   �� *ActualWidth+$  templateRoot��._�5�      �� $ dropDownBorder��6!   #��� ��69   $��1q�6�   #��� ��6�   ._�5�      �� $! DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $" Enabled=�65   .+�5�   &   �� $# canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $$ 
opaqueRect��64   ��6H   �� *
Background+$  dropDownBorder����6�   �� *ActualHeight+$  dropDownBorder����6�   �� *ActualWidth+$  dropDownBorder��5�   '   �� 5�   &   $% ItemsPresenter��65   $& 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $' toggleButton��6   #��z��65   #��z��6a   #��z��6�   $��2��6�   8��  ( 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+66  �� 5�      $) contentPresenter��6#   #��z* 6=   #��z��6z   #��z+ 6�   #- z, 6�   #��z��6-  . .  #��z��6�  # z 6�  #��z��6�  5�       5�      P� 5�      $/ 
PART_Popup��63    �@�HasDropShadow . . �5�      �� $ shadow��6/    � ��$	 0,0,5,5q�6C   �� 5�      $ shadow��6.    �@ Color$	 	#71000000��6B   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6/    � ��$	 95��6K   5�      ]� 5�      0 5�      �� 5�      1 �@��
IsGrouping . 6:   �� 5�      "1 �@%�IsVirtualizingWhenGrouping .  6\   ./�5�      ��  � ��	 .  6F   5�      P� 5�      $/ DropDownScrollViewer��6C    � �� .  . �5�      �� $ 
opaqueRect��63   	 6K   �� *VerticalOffset+$  DropDownScrollViewer�� �@��Top�� 5�      $ 
opaqueRect��64   	 6L   �� *HorizontalOffset+$  DropDownScrollViewer�� �@��Left5�      5�      �� 5�   
   $ 	#FFFFFFFF��6<   �� 5�   
   " ��60   .�5�      ��  �@�OverridesDefaultStyle	 . 66   �� 5�       �@J�	AllowDrop	 . 6*   �� 5�       � ��$	 0��6)   �� 5�       � ��$	 0��6*   �� 5�       �@�FocusVisualStyle	 61   Z� �� 5�       �@��PanningMode$	 VerticalFirst=�69   �� 5�       �@��IsFlicksEnabled	 .  67   �� 5�       � ��	 5�      �� 5�      "
 ��6&   .R�5�      �� $! PART_ContentHost��6'   
������ |�.  $��Hidden=�6l   $��Hidden=�6�   5�      5�      5�      �� 5�   
   "
 ��6;   .R�5�      � $ templateRoot��6    .  5�      �� 5�      $��* �6'   �� 5�      #��� r�6'   $��0 �6z   .+�5�      � $ 
PART_Popup��6    . $��2��6F   #��� .�6�   $��Bottom=�6  ��6Z   �� *IsDropDownOpen+ �� *TemplatedParent+.��5�        $ shadow��64   $ Transparent��6D   #��z 6X   ��6�   �� *ActualWidth+$  templateRoot��._�5�      �� $ dropDownBorder��6!   #��� ��69   $��1q�6�   #��� ��6�   ._�5�      �� $! DropDownScrollViewer��6+   .��5�   "   � $
 grid��6'   $" Enabled=�65   .+�5�   &   �� $# canvas��6-   $
��Left=�6=   $��0��6X   $	��Top=�6c   $��0��6{   .+�5�   *   �� $$ 
opaqueRect��64   ��6H   �� *
Background+$  dropDownBorder����6�   �� *ActualHeight+$  dropDownBorder����6�   �� *ActualWidth+$  dropDownBorder��5�   '   �� 5�   &   $% ItemsPresenter��65   $& 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�      d� 5�      $' toggleButton��6   #��z��65   #��z��6a   #��z��6�   $��2��6�   8��  ( 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+66  �� 5�      $ border��6   8�� #��z��6a   ._�5�      �� $2 PART_EditableTextBox��6   #��z��6<   #��z��6�   8�� #��z��6-  3 6�   �� *
IsReadOnly+ �� *TemplatedParent+6-  5�      5�       5�      P� 5�       � {� .  . �5�      �� $ border��60    �@J�Opacity$
	 0.56Q�6D   5�      P� 5�       �@J�IsKeyboardFocusWithin . . �5�      ��  � ��
	 �   �63   5�      P� 5�      $/ 
PART_Popup��63    �@�HasDropShadow . . �5�      �� $ shadow��6/    � ��$	 0,0,5,5q�6C   �� 5�      $ shadow��6.    �@ Color$	 	#71000000��6B   5�      P� 5�       �@��HasItems .  . �5�      �� $ dropDownBorder��6/    � ��$	 95��6K   5�      ]� 5�      0 5�      �� 5�      1 �@��
IsGrouping . 6:   �� 5�      "1 �@%�IsVirtualizingWhenGrouping .  6\   ./�5     ��  � ��	 .  6F   5     P� 5     $/ DropDownScrollViewer��6C    � �� .  . �5     �� $ 
opaqueRect��63   	 6K   �� *VerticalOffset+$  DropDownScrollViewer�� �@��Top�� 5     $ 
opaqueRect��64   	 6L   �� *HorizontalOffset+$  DropDownScrollViewer�� �@��Left5     5     �� 5	  
   " ��6'   .�5
     ��  �@�FocusVisualStyle8	   61   �� 5      � ��8	  6+   �� 5      � ��8	  6,   �� 5      � ��#	 � ��6+   �� 5      � ��$	 1q�60   �� 5      � ��$
	 Auto=�6K   �� 5      � ��$
	 Auto=�6I   �� 5      � ��$	 6,3,5,3q�6(   �� 5      � ��	 . 6>   �� 5      �@��PanningMode$
	 Both=�69   �� 5      �@��IsFlicksEnabled	 .  67   �� 5      � ��8	  6)   4 5     P� 5      �@��
IsEditable . . �5     ��  � ��	 .  62   �� 5      � ��$	 2q�60   �� 5      � ��8	  61   5     5     5     .��5      �  5!  
   �� 5"     $��4* �6   �� 5#     $
��8.5* �6   5 � RowDefinitions5 5&  
   �� 5'     $��1* �6   �� 5(     $	��10* �6   .+�5+  
   �� 6 �� Orientation$6 
Horizontal=�6   $��Center=�5,     $��	17 25 5 5q�5-     $��2��5.     .+�5/     �� $��Город:��6    # TxbTitle#��[# 50     $��Regular"�51     �� 52     -   5        $��
CmbxRegion��52     $��17(�53     #��[! 55     $	��250��56     $��30��57     58     �� 5:  
   $ 5��6   $��1��5;     $��3��5<     $��5 5 5 20q�5=     ���#F6F6F6._�5?     �� -   5        7 ��Name$7 
ListWorker��5A     
������ 
������ $	��620��5B      $ ListDef#��[$ 5C     $��Center=�5D     $��Hidden=�5E     ��5G     �� 5H     .R�5I     �� $ 5��6!   8 �� Padding$8 3q�5J  !   $��Center=�5K  !   $	��170��5L  %   $	��100��5M  %   
�������9 J� Effect9 5O     3  -System.Windows.Media.Effects.DropShadowEffect  5P  "   :   
BlurRadius$: 10Q�63   ;   Opacity$	; 0.1Q�6C   ._�5R     � 5 5S  "   �� 5T  &   $��4* �64   �� 5U  &   $��1* �64   .+�5W  "   �� $��60��6(   $��0��5X  ,   $��Center=�5Y  (   $��5q�5Z  ,   ��5[  ,   �� *GetUserPhoto+�� 5\  "   $��1��6-   .+�5]  &   �� $��SemiBold"�5^  0    % TxbListBlack#��[% 5_  )   $��Center=�5`  0   $
��Wrap=�5b  0   ��5a  0   �� *GetFullName+5b  0   �� 5c  &   $	��155��5d  ,   #��[% 5e  %   $
��Wrap=�5f  ,   $	��Top=�5g  0   $��1��5h  0   ��5i  0   �� *	Role.Name+5j  #   5k     5l     5m     5o     5p      � 5r  
   -   5        <  �Name$< FrameCRM��5t     $��1��5r     $��1��5s     =  � NavigationUIVisibility$= Hidden=�5u     5v     5w     