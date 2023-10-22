import {IDataGridOptions} from "devextreme-react/data-grid";
import {AxiosError} from "axios";
import {DataErrorOccurredEvent} from "devextreme/ui/data_grid";


export const defaultDatagridConfig: IDataGridOptions = {
	/**
	 * Elküldjük az összes adatot amit megadtunk a Formban, nem csak azokat amik frissültek!
	 * @param event
	 */
	onRowUpdating: (event: any) => {
		event.newData = { ...event.oldData, ...event.newData };
	},

	onDataErrorOccurred: (data: DataErrorOccurredEvent)=>{
		// Olyan error eseteén mely DTO modell validációs esetén történik
		if (data.error instanceof AxiosError) {
			const axiosError = data.error as AxiosError;
			if(axiosError.code == 'ERR_BAD_REQUEST'){
				data.error!.message = axiosError.response?.data as string;
			}
			// ha kaptunk response-t, ergo tudott kapcsolatot létrehozni az API-val!
			if (axiosError.response) {
				const errors = (axiosError.response as any).data.errors
				if (errors) {
					//felsoroljuk a datagrid HIBA sorába a hibákat, validációs hibákat!
					data.error!.message = Object.values(errors).join("\n")
				}
			}
		}

	},
	allowColumnReordering:true,
	rowAlternationEnabled:true,
	allowColumnResizing: true,
	showBorders:true,
	groupPanel:{
		visible: true
	},
	searchPanel: {
		visible: true,
		highlightCaseSensitive: true
	},
	export: {
		enabled: true,
		formats: ["xlsx"],
	},
	filterRow:{
		visible: true,
	},
	filterPanel:{
		visible:true
	},
	filterBuilderPopup: {
		position: "center",
	},
	headerFilter:{
		visible:true,
	},

	grouping:{
		autoExpandAll: false
	},
	pager: {
		allowedPageSizes: [10, 15, 50, 100],
		showPageSizeSelector: true,
		showNavigationButtons: true,
		visible: true,
		displayMode:"full",
		showInfo: true
	},
	paging: {
		enabled: true,
	},
	stateStoring: {},

}

export const defaultDatagridEditing:IDataGridOptions = {
	editing:{
		allowAdding:true,
		allowDeleting:true,
		allowUpdating:true,
		useIcons:true
	}

}