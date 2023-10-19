import i18n from "i18next";
import LanguageDetector from "i18next-browser-languagedetector";

import ResourcesHU from "../localization/resource.hu.json"
import ResourcesEN from "../localization/resource.en.json"

i18n
	.use(LanguageDetector)
	.init({
		debug: true,
		lng: "hu",
		fallbackLng: "hu", // use en if detected lng is not available
		keySeparator: ".",

		interpolation: {
			escapeValue: false // react already safes from xss
		},
		defaultNS: "Resources",
		resources: {
			//TODO: Megcsinálni az eddigiekhez az angol nyelvő megfelelőjét!
			en:{
				Resources:ResourcesEN
			},
			hu: {
				Resources:ResourcesHU
			},

		},

	});

export const i18next =  i18n;