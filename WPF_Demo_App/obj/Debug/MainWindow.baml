   M S B A M L   `   `   `  ����G  CWPF_Demo_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:WPF_Demo_AppWPF_Demo_App  5   	   ?$clr-namespace:WPF_Demo_App.ConverterWPF_Demo_App.Converter  5
   	       WPF_Demo_App.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:WPF_Demo_App     5   	   :	converter$clr-namespace:WPF_Demo_App.Converter     5
   	     � Title$  
MainWindow��5   	   $
��1175��5	   	    � 	Resources 5      E   ?WPF_Demo_App.Converter.PeopleCollectionViewToCountriesConverter ,  (PeopleCollectionViewToCountriesConverter �� 
TargetType �� Property �� Value��%1  &	        '��        5   
   6=   �� 5   
   " ��6   .�5      ��  � ��$ Center=�64   �� 5       � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 12(�6)   �� 5       � ��$ 28��6'   �� 5       � ��$
 Auto��6&   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $	��85* �6   �� 5      $
��310* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��2* �6#   �� 5      $��1* �6#   .+�5!      �� $��0��6   $��1��6!   $��65��61   $	��300��6=   $��Application��6I   $��Center=�6_   $��Center=�6�   $��40(�6�   �� 5"      $��10q�6   $��0��6#   $��2��60   $��35��6@   $	��180��6L   $
��Left=�6X   $��Center=�6z   $��15(�6�    �� 
IsEditable . ��5#   )   �� *
PeopleView+ �� 	Converter# [  	 �� SelectedItem	 6�   �� *SelectedCountry+5$      � 5%   
   $��1��6    5&      �� 5'      $��15 �6#   �� 5(      $��1* �6#   �� 5)      $��15 �6#   .+�5+      �� $��1��6   .��5,      �� .+�5-      �� $��5q�6F   ��6#   �� *
PeopleView+��5.      �� 5/      .R�50   "   � $
��Left=�6,   51      ��53      �� 54      .R�55   "   � $	��120��6'   $	��170��63   $��8q�6@    56   &   �� 57   *   $��10 �68   �� 58   *   $��* �68   �� 59   *   $��10 �68   .+�5;   &   �� $��1��6-   $��2q�6:   
�������
���iii�
 J� Opacity$	
 0.7Q�6|   ._�5<   *   ��  �� Orientation$ Vertical=�65   .+�5=   .   �� $	��Top=�64   ��6L   �� *Name+�� 5>   .   $��Center=�64   ��6O   �� *	Country+�� 5?   .   $��Bottom=�64   ��6O   �� *Phone+5@   +   5A   '   5B   #   5C      5E      5F      5G      5H      5I      5J      