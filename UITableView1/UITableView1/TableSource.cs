﻿using System;
using Foundation;
using UIKit;


namespace UITableView1
{
	public class TableSource : UITableViewSource
	{
		string[] TableItems;
		string CellIdentifier = "Celda";
		UIViewController Controller;

		public TableSource(){}

		public TableSource(String[] items, UIViewController controller)
		{
			TableItems = items;
			Controller = controller;
		}

        /// <summary>
        /// Nos ayudara a crear cada una de nuestras celdas, donde tomara como origen nuestro source
        /// </summary>
        /// <returns>The cell.</returns>
        /// <param name="tableView">Table view.</param>
        /// <param name="indexPath">Index path.</param>
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(CellIdentifier);
			string item = TableItems[indexPath.Row];

			if (cell  == null)
			{
				cell = new UITableViewCell(UITableViewCellStyle.Default, CellIdentifier);
			}

			cell.TextLabel.Text = item;

			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return TableItems.Length;
		}



		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			//SE CREA LAS ALERTAS
			var okAlertController = UIAlertController.Create("Fila selecionada",
                                                             TableItems[indexPath.Row],
                                                             UIAlertControllerStyle.Alert);

			//SE CREAN LAS ACCIONES
			okAlertController.AddAction(UIAlertAction.Create("Aceptar", UIAlertActionStyle.Default, null));

			//SE PRESENTA LA ALERTA
			Controller.PresentViewController(okAlertController, true, null);

			tableView.DeselectRow(indexPath, true);
		}
	}
}

