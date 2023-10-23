import {configureStore} from "@reduxjs/toolkit";
import {drawerReducer} from "./drawerSlice/drawer.slice.ts";
import {userReducer} from "./userSlice/user.slice.ts";
import {dictionaryDatasourceReducer} from "./dictionaryDatasourceSlice/dictionaryDatasource.slice.ts";
import {currentProjectReducer} from "./currentProject/drawer.slice.ts";

export const store = configureStore({
	reducer: {
		drawer: drawerReducer,
		user: userReducer,
		dictionaryDatasource: dictionaryDatasourceReducer,
		currentProject: currentProjectReducer

	},
});
