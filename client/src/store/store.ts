import {configureStore} from "@reduxjs/toolkit";
import {drawerReducer} from "./drawerSlice/drawer.slice.ts";
import {userReducer} from "./userSlice/user.slice.ts";

export const store = configureStore({
	reducer: {
		drawer: drawerReducer,
		user: userReducer
	},
});
