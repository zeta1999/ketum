const ENV = {
  dev: {
    apiUrl: 'http://localhost:44304',
    oAuthConfig: {
      issuer: 'http://localhost:44304',
      clientId: 'Ketum_App',
      clientSecret: '1q2w3e*',
      scope: 'Ketum',
    },
    localization: {
      defaultResourceName: 'Ketum',
    },
  },
  prod: {
    apiUrl: 'http://localhost:44304',
    oAuthConfig: {
      issuer: 'http://localhost:44304',
      clientId: 'Ketum_App',
      clientSecret: '1q2w3e*',
      scope: 'Ketum',
    },
    localization: {
      defaultResourceName: 'Ketum',
    },
  },
};

export const getEnvVars = () => {
  // eslint-disable-next-line no-undef
  return __DEV__ ? ENV.dev : ENV.prod;
};
