import {configureStore} from "@reduxjs/toolkit";
import {drawerReducer} from "./drawerSlice/drawer.slice.ts";

export const store = configureStore({
	reducer: {
		drawer: drawerReducer,
	},
});
