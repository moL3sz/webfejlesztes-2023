import './App.css'
import {Layout} from "./components/Layout/Layout.tsx";
import {Provider} from "react-redux";
import {store} from "./store/store.ts";
import {I18nextProvider} from "react-i18next";
import {i18next} from "./config/i18next.ts";
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import {routes} from "./config/routes.ts";
import {ProjectRegistrar} from "./pages/ProjectRegistrar/ProjectRegistrar.tsx";
import {Login} from "./pages/Login/Login.tsx";
import {Register} from "./pages/Register/Register.tsx";
import {Dashboard} from "./pages/Dashboard/Dashboard.tsx";
import {ProjectDashboard} from "./pages/ProjectDashboard/ProjectDashboard.tsx";

function App() {

	return (
		<Provider store={store}>
			<I18nextProvider i18n={i18next}>
				<Router>
					<Layout>
						<Routes>
							<Route path={"/"} element={null}/>
							<Route path={routes.projects.create} element={<ProjectRegistrar/>}/>
							<Route path={routes.login} element={<Login/>}/>
							<Route path={routes.register} element={<Register/>}/>
							<Route path={routes.dashboard} element={<Dashboard/>}/>
							<Route path={routes.projects.manage} element={<ProjectDashboard/>}/>

						</Routes>
					</Layout>

				</Router>

			</I18nextProvider>


		</Provider>
	)
}

export default App
