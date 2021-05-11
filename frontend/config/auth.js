

import { UserAgentApplication } from 'msal'

const config = {
  auth: {
    clientId: process.env.VUE_APP_CLIENT_ID, //Application client id
    authority: `${process.env.VUE_APP_AUTHORITY_BASE}/${process.env.VUE_APP_TENANT_ID}`,
    redirectUri: window.location.origin,
    postLogoutRedirectUri: window.location.origin,
  },
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