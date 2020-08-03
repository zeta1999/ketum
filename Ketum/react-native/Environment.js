const ENV = {
  dev: {
    apiUrl: 'http://localhost:44321',
    oAuthConfig: {
      issuer: 'http://localhost:44321',
      clientId: 'ketum_App',
      clientSecret: '1q2w3e*',
      scope: 'ketum',
    },
    localization: {
      defaultResourceName: 'ketum',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44321',
    oAuthConfig: {
      issuer: 'http://localhost:44321',
      clientId: 'ketum_App',
      clientSecret: '1q2w3e*',
      scope: 'ketum',
    },
    localization: {
      defaultResourceName: 'ketum',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
