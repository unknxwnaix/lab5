   M S B A M L   `   `   `  ����B  >WpfApp3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp3WpfApp3  5   	       WpfApp3.MainWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.8.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp3     5   	     � Title$  
MainWindow��5	   	   $	��250��6   $	��350��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   �� $��Center=�6   $
��Wrap=�61   $��Авторизация��6E   $��Center=�6X   $��39��6s   $	��350��6    �� TextAlignment$ Center=�6�   $��20(�6�   �� 5   
   $��Center=�6   $
��Wrap=�61   $��  Логин��6E   $��Center=�6T   $��39��6o   $��1��6{   $	��350��6�   $��14(�6�   �� 5   
   $��Center=�6   $
��Wrap=�61   $��  Пароль��6E   $��Center=�6U   $��39��6p   $��3��6|   $	��350��6�   $��14(�6�   �� 5   
   -   5         ��Name$ tb��5   A   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите логин��6   $��Center=�6M   $��2��6j    �� TextWrapping$
 Wrap=�6w   $�� ��6�   $��Center=�6�   $	��330��6�   $��39��6�   $��14(�6�   G� 5   
   -   5         G�Name$ pb��5      $��Center=�6"   $! Введите пароль��6?   $��4��6o   $��Center=�6|   $	��330��6�   $��39��6�   �� 5   
   -   5         ��Name$
 Auth��5       #  MaterialDesignFlatLightBgButton#��[  5      	 � ToolTip$#	 MaterialDesignFlatLightButton��5      $"��Авторизоваться��5      $��0,4,0,3q�5    x   $��5��6�   {�6   �� *DataContext.ControlsEnabled+
 �� RelativeSource
 �� *FindAncestor+ �� AncestorType$ WindowL�6�   5!      5#      