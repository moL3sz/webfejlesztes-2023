import {NavigationListItemGroupType} from "../../config/@types/navigationListItem.type.ts";
import {useTranslation} from "react-i18next";
import {memo} from "react";


export const NavigationGroupItem = memo(({icon, text}:NavigationListItemGroupType)=>{

	const {t} = useTranslation();
	return (
		<div className={"pl-2"}>
			<i className={"mr-6 text-base dx-icon dx-icon-" + icon}></i>
			<span>
				{t(text)}
			</span>
		</div>
	)

})