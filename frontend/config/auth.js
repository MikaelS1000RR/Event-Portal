

import { UserAgentApplication } from 'msal'

const config = {
  auth: {
     clientId: "1a602afd-b047-4730-892f-715f551f9c97",
    authority: "https://login.microsoftonline.com/geshdo.onmicrosoft.com",
    redirectUri: window.location.origin,
    postLogoutRedirectUri: window.location.origin
  
  }
};

const tokenConfig = {
  scopes: ['User.Read']
};

export const auth = new UserAgentApplication(config);

auth.handleRedirectCallback(error => {
  if (error) {
    console.error(error);
  }
});

export const getToken = async () => {
  const token = await auth
    .acquireTokenSilent(tokenConfig)
    .catch(() => auth.acquireTokenRedirect(tokenConfig))
    .then(({ idToken }) => idToken?.rawIdToken);

  if (!token) {
    auth.loginRedirect();
  }

  return token;
};