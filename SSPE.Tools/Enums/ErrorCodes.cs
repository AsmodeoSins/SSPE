namespace SSPE.Tools.iCam7000Wrapper.Enums
{
    public enum ErrorCodes
    {
        NONE = unchecked(0x00000000),
        API_UNSUPPORTED = unchecked((int)0x84000020),
        TIME_OUT = unchecked((int)0x84000009),
        LICENSE = unchecked((int)0x84000008),
        IMP_VERSION = unchecked((int)0x84000007),
        PARAMETER = unchecked((int)0x84000006),
        ICAM_FAILURE = unchecked((int)0x84000005),
        AUTHENTICATION = unchecked((int)0x84000004),
        SOCKET = unchecked((int)0x84000003),
        CLOSE = unchecked((int)0x84000002),
        OPEN = unchecked((int)0x84000001),
        WIEGAND_OUT_DISABLED = unchecked((int)0x84000011),
        RELAY_ALREADY_OPEN = unchecked((int)0x84000012),
        LOW_ICAM_VERSION = unchecked((int)0x84000014),
        UPGRADE_NOT_REQUIRED = unchecked((int)0x84000018),
        UPGRADE_FAILED = unchecked((int)0x84000015),
        UPGRADE_OBSOLETE_DAT_FILES = unchecked((int)0x84000017),
        UPGRADE_ALREADY_OPEN = unchecked((int)0x84000016)
    }
}
